using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlogApi.ExceptionHande;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Serialization;
using Blog.Service.infrastructure.Service;
using Blog.Core.UnitOfWork;
using Blog.Core.ViewModel.Articles;
using Blog.Core.ViewModel.EntityToViewModelPropertyMapping;
using Blog.Core.ViewModel.Validation;
using Blog.infrastructure.Entity;
using Blog.Core.Repository;
using Blog.infrastructure.Service.TypeHelp;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Http;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlogApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(option =>
            {
                option.AddPolicy("any", builder =>
                {
                    //允许localhost中8080端口跨域访问所有api
                    builder.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    
                });
            });
            //添加配置MVC
            services.AddMvc(options => {
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
                //设置返回Json时名字首字母小写
                .AddJsonOptions(option => { option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); })
                .AddFluentValidation();


            //添加配置EF数据库
            services.AddDbContext<MyDbContext>(
                options=>
                {
                    //将敏感的数据写入系统环境变量中，避免在Git上暴露信息
                    //连接字符串后要加  Character Set=utf8  ，不然中文会乱码
                    options.UseMySQL(Configuration["TestDatabaseConnectionStr"]);
                });

            //身份认证和HTTPS重定向
            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "https://localhost:5001";
            //        options.ApiName = "restapi";
            //    });

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});


            ////使用IdentitySever 保护API
            //services.Configure<MvcOptions>(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser().Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            //工作单元
            services.AddScoped<IUnitForWork, UnitForWork>();
            //注册DAO组件
            services.AddScoped<IArticleRepository, ArticleRepository>();
            

            //添加AutoMapper
            services.AddAutoMapper();
            //添加Mode-ViewModel的验证
            services.AddTransient<IValidator<ArticleAddOrUpdateViewModel>, ArticleAddViewModelValidation>();
            //添加属性字典映射服务（排序用）
            var propertyMappingContainer = new PropertyMappingContainer();
            propertyMappingContainer.Register<SortArticlePropertyMapping>();
            services.AddSingleton<IPropertyMappingContainer>(propertyMappingContainer);
            services.AddTransient<ITypehelper, TypeHelper>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/


            //获取配置字符串
            //app.Run(async (context) =>
            //{
            //    var welcome = Configuration["TestDatabaseConnectionStr"];
            //    await context.Response.WriteAsync(welcome);
            //});


            //适用API的自定义的全局异常处理方法
            //异常处理一定要在MVC前面！
            app.UseMyGlobalExceptionHandler(loggerFactory);

            //添加允许跨域访问配置
            app.UseCors("any");
            //测试用时停用HTTPS和身份验证
            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseMvc();



            //返回错误页面，适用MVC
            //app.UseDeveloperExceptionPage();


            //app.UseStaticFiles();
        }
    }
}
