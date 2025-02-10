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
        var requestUrl = httpContext.Request.Path.ToString().ToLower();
        if (requestUrl == "/login" || requestUrl == "/login/index")
            goto result;

        result:
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
