// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSDLDotNetCore.ConsoleApp.AdoDotNetExamples;
using SSDLDotNetCore.ConsoleApp.DapperExamples;
using SSDLDotNetCore.ConsoleApp.EFCoreExamples;
using SSDLDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update("13", "update title", "update author", "update content");
//adoDotNetExample.Delete("13");
//adoDotNetExample.Edit("13");
//adoDotNetExample.Edit("12");

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample EFCoreExample = new EFCoreExample();
//EFCoreExample.Run();

// Dependency Injection
var connectionString = ConnectionString.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped<AdoDotNetExample>(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped<DapperExample>(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>(); // EFCore

// AdoDotNet
//var adoDotNetExample = serviceProvider.GetService<AdoDotNetExample>();
//adoDotNetExample.Read();

// Dapper
var dapperExample = serviceProvider.GetService<DapperExample>();
dapperExample.Run();

Console.ReadKey();