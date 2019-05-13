using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BlogApi
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //配置Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()                                           //设置最小log等级为Debug
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)  //当log以Microsoft开头时，最小log等级为Information
                .Enrich.FromLogContext()                                        //不知道 大概是配置字体之类的
                .WriteTo.Console()                                              //将log写入控制台
                .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)//将log写入文件，并且每天新建一个文件
                .CreateLogger();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();//将Serilog加入app中

    }
}
