namespace Proyect.Middleware
{
    public class ShabatMiddleware
    {
        private readonly  RequestDelegate _next;

        public ShabatMiddleware(RequestDelegate next)
        {

        _next = next; 
        }

        public async Task Invoke(HttpContext context) {

            if (DayOfWeek.Friday == DateTime.Now.DayOfWeek) { 
            
            
                context.Response.StatusCode=StatusCodes.Status400BadRequest;
                context.Response.ContentType="application/json";
                await context.Response.WriteAsync("שבת היא מנוחה ואסור לעשות בה מטלות!!!!!!");
                return;
            
            
            
            }
            await _next(context);






        }
    }
}
