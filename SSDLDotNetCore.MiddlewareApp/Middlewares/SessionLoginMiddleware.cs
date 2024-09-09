using System.Globalization;

namespace SSDLDotNetCore.MiddlewareApp.Middlewares
{
    public class SessionLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/" || context.Request.Path.ToString().ToLower() == "/Login".ToLower())
                goto result;

            string name = context.Session.GetString("name")!;
            if(name is null)
            {
                context.Response.Redirect("/");
                return;
            }

            result:
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
