using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSDLDotNetCore.MvcApiCall.Models;

namespace SSDLDotNetCore.MvcPagination.Controllers;

public class BlogController : Controller
{
    private readonly HttpClient _httpClient;

    public BlogController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
    {
        BlogResponseModel model = new BlogResponseModel();
        var response = await _httpClient.GetAsync($"api/Blog/{pageNo}/{pageSize}");
        if(response.IsSuccessStatusCode)
        {
            var jsonStr = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;
        }
        return View("BlogIndex", model);
    }
}
