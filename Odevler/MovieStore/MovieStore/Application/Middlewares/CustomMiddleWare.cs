using MovieStore.Services;
using System.Diagnostics;
using System.Net;

namespace MovieStore.Application.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {

            DateTime dateTime = DateTime.Now;
            try
            {
                string msgSuccesText = "[Success] ";
                string message = msgSuccesText;

                message += $"[Request]: {context.Request.Method} - {context.Request.Path}";
               
                Console.ForegroundColor = ConsoleColor.Green;
                _loggerService.Write(message);

                await _next(context);
                message = msgSuccesText;

                message += $"[Response]: {context.Request.Method} - {context.Request.Path} "
                        + $"responded {context.Response.StatusCode } in "
                        + $"{ GetElapsedTime(dateTime)} ms.";
                
                _loggerService.Write(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                await Task.Run(() =>
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    string message = $"[Request]: {context.Request.Method} - {context.Request.Path} "
                            + $"Error Message: {ex.Message} in {GetElapsedTime(dateTime) } ms.";
                    _loggerService.Write(message);
                    _loggerService.Write(ex.ToString());

                    var result = Newtonsoft.Json.JsonConvert.SerializeObject(
                        new { error = ex.Message },
                        Newtonsoft.Json.Formatting.None);
                    return context.Response.WriteAsync(result);
                });
            }
        }

        private object GetElapsedTime(DateTime dateTime) => (DateTime.Now - dateTime).Milliseconds;
        
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseLogAndError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
