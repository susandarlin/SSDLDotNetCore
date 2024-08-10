using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.RealtimeChartApp.Hubs;
using SSDLDotNetCore.RealtimeChartApp.Models;

namespace SSDLDotNetCore.RealtimeChartApp.Controllers;

public class PieChartController : Controller
{
    private readonly AppDbContext _db;
    private readonly IHubContext<ChartHub> _hubContext;

    public PieChartController(AppDbContext db, IHubContext<ChartHub> hubContext)
    {
        _db = db;
        _hubContext = hubContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Save(TblPieChart reqModel)
    {
        await _db.TblPieCharts.AddAsync(reqModel);
        await _db.SaveChangesAsync();

        var lst = await _db.TblPieCharts.AsNoTracking().ToListAsync();

        var data = lst.Select(x => new PieChartModel
        {
            name = x.PieChartName,
            y = x.PieChartValue
        });

        await _hubContext.Clients.All.SendAsync("ReceivePieChart", data);
        return RedirectToAction("Create");
    }
}

public class PieChartModel
{
    public string name { get; set; }
    public decimal y { get; set; }
}
