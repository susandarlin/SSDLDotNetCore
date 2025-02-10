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

        var cookies = httpContext.Request.Cookies;
        if (cookies["UserId"] is null || cookies["SessionId"] is null)
        {
            httpContext.Response.Redirect("/login");
            goto result;
        }

        string UserId = cookies["UserId"]!.ToString();
        string SessionId = cookies["SessionId"]!.ToString();

        var login = appDbContext.Logins.FirstOrDefault(x => 
            x.SessionId == SessionId && 
            x.UserId == UserId);
        if(login is null)
        {
            httpContext.Response.Redirect("/login");
            goto result;
        }

        if(login.SessionExpired < DateTime.Now)
        {
            httpContext.Response.Redirect("/login");
            goto result;
        }

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
