using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace SSDLDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

		public CanvasJsController(ILogger<CanvasJsController> logger)
		{
			_logger = logger;
		}

		public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart...");
            return View();
        }

        public IActionResult PyramidChartsWithLabelsInside()
        {
            return View();
        }

        public IActionResult BubbleCharts()
        {
            return View();
        }
    }
}
