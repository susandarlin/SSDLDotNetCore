using Microsoft.AspNetCore.Mvc;
using SSDLDotNetCore.MvcApp.Models;

namespace SSDLDotNetCore.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult ColumnWithDataLables()
        {
            ColumnWithDataLabelsModel model = new ColumnWithDataLabelsModel();
            model.Categories = new List<string>()
            {
                "Jan",
                "Feb",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Aug",
                "Sep",
                "Oct",
                "Nov",
                "Dec"
            };
            model.Inflation = new List<double>
            {
                2.3,
                3.1,
                4.0,
                10.1,
                4.0,
                3.6,
                3.2,
                2.3,
                1.4,
                0.8,
                0.5,
                0.2
            };

            return View(model);
        }
    }
}
