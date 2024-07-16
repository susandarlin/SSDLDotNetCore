using Microsoft.AspNetCore.Mvc;

namespace SSDLDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }
    }
}
