namespace WebApplication1.Middlewares
{
    public class HelloWorldMiddleware
    {
        readonly RequestDelegate _next;
        public HelloWorldMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Hello World!");
            await _next.Invoke(context);
            Console.WriteLine("Bye World!");
        }
      
    }  public static  class HelloMiddlewareExtension
        {
            public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<HelloWorldMiddleware>();
            }
        }
}
