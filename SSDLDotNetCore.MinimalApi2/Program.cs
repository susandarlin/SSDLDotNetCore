using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.MinimalApi2;
using SSDLDotNetCore.MinimalApi2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.MapGet("/api/blog", (AppDbContext _db) =>
{
    List<BlogModel> lst = _db.blog.OrderByDescending(x => x.BlogId).ToList();
    return Results.Ok(lst);
})
.WithName("GetBlogs")
.WithOpenApi();

app.MapGet("/api/blog/{pageNo}/{pageSize}", (AppDbContext _db, int pageNo, int pageSize) =>
{
    int rowCount = _db.blog.Count();

    int pageCount = rowCount / pageSize;
    if (rowCount % pageSize > 0)
        pageCount++;

    if (pageNo > pageCount)
        return Results.BadRequest(new { Message = "Invalid PageNo." });

    var lst = _db.blog
        .OrderByDescending(x => x.BlogId)
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    BlogResponseModel model = new();
    model.Data = lst;
    model.PageNo = pageNo;
    model.PageSize = pageSize;
    model.PageCount = pageCount;
    return Results.Ok(model);
})
.WithName("GetBlogByPagination")
.WithOpenApi();

app.MapPost("/api/blog", (AppDbContext _db, BlogModel blog) =>
{
    _db.blog.Add(blog);
    int result = _db.SaveChanges();
    string message = result > 0 ? "Saving Successful." : "Saving Failed.";
    return Results.Ok(message);
})
.WithName("BlogCreate")
.WithOpenApi();

app.MapPut("/api/blog", (AppDbContext _db, int id, BlogModel blog) =>
{
    var item = _db.blog.FirstOrDefault(x => x.BlogId == id);
    if(item is null)
    {
        return Results.BadRequest("No data found.");
    }

    item.BlogTitle = blog.BlogTitle;
    item.BlogAuthor = blog.BlogAuthor;
    item.BlogContent = blog.BlogContent;

    int result = _db.SaveChanges();
    string message = result > 0 ? "Updating Successful." : "Updating Failed.";
    return Results.Ok(message);
})
.WithName("BlogUpdate")
.WithOpenApi();

app.MapPatch("/api/blog", (AppDbContext _db, int id) =>
{
    var item = _db.blog.FirstOrDefault(x => x.BlogId == id);
    if(item is null)
    {
        return Results.BadRequest("No data found.");
    }
    return Results.Ok(item);
})
.WithName("BlogEdit")
.WithOpenApi();

app.MapDelete("/api/blog", (AppDbContext _db, int id) =>
{
    var item = _db.blog.FirstOrDefault(x => x.BlogId == id);
    if(item is null)
    {
        return Results.BadRequest("No data found.");
    }

    _db.Remove(item);
    var result = _db.SaveChanges();
    var message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
    return Results.Ok(message);
})
.WithName("BlogDelete")
.WithOpenApi();

app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
