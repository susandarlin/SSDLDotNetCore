using SSDLDotNetCore.LoginApp.EFDbContext;

namespace SSDLDotNetCore.LoginApp.Middlewares;

public class CookieMiddleware
{
    private readonly RequestDelegate _next;

    public CookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, AppDbContext appDbContext)
    {
        await _next(httpContext);
    }
}

public static class CookieMiddlewareExtensions
{
    public static IApplicationBuilder UseCookieMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CookieMiddleware>();
    }
}
