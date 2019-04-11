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
  
            services.AddDbContext<MyDbContext>(
                options=>
                {
                    options.UseMySQL(Configuration["TestDatabaseConnectionStr"]);
                });
            services.AddScoped<IUnitForWork, UnitForWork>();
            
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
