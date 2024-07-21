using Microsoft.AspNetCore.Mvc;

namespace SSDLDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }

        public IActionResult InterpolationLineChart()
        {
            return View();
        }

        public IActionResult SteppedLineCharts()
        {
            return View();
        }

    }
}
