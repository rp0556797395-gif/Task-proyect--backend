using Microsoft.AspNetCore.Builder;
using Proyect.Middleware;

namespace Proyect
{
    public static class Extensions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ShabatMiddleware>();
        }
    }
}
