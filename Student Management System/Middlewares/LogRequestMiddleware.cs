namespace Student_Management_System.Middlewares
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"The Request URL is: {context.Request.Path}");
            await _next(context);
        }
    }
}
