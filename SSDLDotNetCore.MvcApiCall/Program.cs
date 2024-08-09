using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using SSDLDotNetCore.MvcApiCall;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* Http Client API Call */
//builder.Services.AddScoped<HttpClient>();
//builder.Services.AddScoped(n => new HttpClient()
//{
//    BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")!)
//});


/* Rest Client API Call */
//builder.Services.AddScoped(n => new RestClient(builder.Configuration.GetValue<string>("ApiUrl")!));


/* Refit Client API Call */
builder.Services
    .AddRefitClient<IBlogApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
