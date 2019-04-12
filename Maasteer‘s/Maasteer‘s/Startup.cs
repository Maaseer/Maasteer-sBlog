using Blog.Core;
using Blog.Core.Database;
using Blog.infrastructure.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Maasteer_s
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
  

            //注入依赖项
            services.AddDbContext<MyDbContext>(
                options=>
                {
                    //将敏感的数据写入系统环境变量中，避免在Git上暴露信息
                    options.UseMySQL(Configuration["TestDatabaseConnectionStr"]);
                });
            //工作单元
            services.AddScoped<IUnitForWork, UnitForWork>();
            //方法
            services.AddScoped<IRepository, ArticleRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Run(async (context) =>
            //{
            //    var welcome = Configuration["TestDatabaseConnectionStr"];
            //    await context.Response.WriteAsync(welcome);
            //});
            app.UseMvc();
         //   app.UseStaticFiles();
        }
    }
}
