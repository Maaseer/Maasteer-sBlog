using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BlogApi.ExceptionHande
{
    public static class GlobalExceptionHandler
    {
        public static void UseMyGlobalExceptionHandler(this IApplicationBuilder app,ILoggerFactory logger)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    //设置返回状态码和格式
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    //若异常不为空，则写入日志
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        var log = logger.CreateLogger("BlogApi.ExceptionHande.GlobalExceptionHandler");
                        log.LogError(500, ex.Error, ex.Error.Message);
                        //log.LogInformation(ex?.Error?.Message ?? "An Exception has be throw------------------------");
                    }
                    
                    //返回异常信息
                    await context.Response.WriteAsync(ex?.Error?.Message ?? "An Exception has be throw");
                });
            });
        }
    }
}