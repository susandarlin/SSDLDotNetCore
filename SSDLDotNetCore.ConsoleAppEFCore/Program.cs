using SSDLDotNetCore.ConsoleAppEFCore.Databases.Models;

AppDbContext db = new AppDbContext();
var lst = db.TblPieCharts.ToList();

for (int i = 0; i < lst.Count; i++)
{
    Console.WriteLine(lst[i].PieChartName);
    Console.WriteLine(lst[i].PieChartValue);
    Console.WriteLine("-------------------------------");
}

Console.ReadLine();