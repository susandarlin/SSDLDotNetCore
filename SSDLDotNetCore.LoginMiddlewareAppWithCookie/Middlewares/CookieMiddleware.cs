using SSDLDotNetCore.LoginMiddlewareAppWithCookie.EFDbContext;
using System.Net;

namespace SSDLDotNetCore.LoginMiddlewareAppWithCookie.Middlewares
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMessageWriter is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext, AppDbContext appDbContext)
        {
            var requestUrl = httpContext.Request.Path.ToString().ToLower();
            if (requestUrl == "/login" || requestUrl == "/login/index")
                goto result;

            var cookies = httpContext.Request.Cookies;
            if (cookies["UserId"] is null  || cookies["SessionId"] is null)
            {
                httpContext.Response.Redirect("/Login");
                goto result;
            }

            var userId = cookies["UserId"]!.ToString();
            var sessionId = cookies["SessionId"]!.ToString();

            var login = appDbContext.Login.FirstOrDefault(x => x.SessionId == sessionId && x.UserId == userId);
            if (login is null)
            {
                httpContext.Response.Redirect("/Login");
                goto result;
            }

            if(DateTime.Now > login.SessionExpired)
            {
                httpContext.Response.Redirect("/Login");
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

}
