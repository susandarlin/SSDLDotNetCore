using Microsoft.AspNetCore.Mvc;

namespace SSDLDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult AreaChart()
        {
            return View();
        }
    }
}
