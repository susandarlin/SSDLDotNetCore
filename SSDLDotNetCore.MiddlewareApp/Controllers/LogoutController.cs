using Microsoft.AspNetCore.Mvc;

namespace SSDLDotNetCore.MiddlewareApp.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
  