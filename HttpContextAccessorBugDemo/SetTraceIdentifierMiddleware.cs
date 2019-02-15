using System.Threading.Tasks;

namespace HttpContextAccessorBugDemo
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class SetTraceIdentifierMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SetTraceIdentifierMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _httpContextAccessor.HttpContext.TraceIdentifier = "BUGGYTRACE:12345";

            await _next(context);
        }
    }

    public static class SetTraceIdentifierMiddlewareExtensions
    {
        public static IApplicationBuilder UseSetTraceIdentifier(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SetTraceIdentifierMiddleware>();
        }
    }
}
