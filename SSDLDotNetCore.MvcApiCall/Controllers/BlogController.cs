using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SSDLDotNetCore.MvcApiCall.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SSDLDotNetCore.MvcPagination.Controllers;

public class BlogController : Controller
{
    private readonly RestClient _restClient;

    public BlogController(RestClient restClient)
    {
        _restClient = restClient;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
    {
        BlogResponseModel model = new BlogResponseModel();

        RestRequest restRequest = new RestRequest($"api/Blog/{pageNo}/{pageSize}", Method.Get);
        var response = await _restClient.ExecuteAsync(restRequest);
        if(response.IsSuccessStatusCode)
        {
            var jsonStr = response.Content;
            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr!)!;
        }
        return View("BlogIndex", model);
    }

    [ActionName("Create")]
    public IActionResult BlogCreate(BlogModel blog)
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> BlogSave(BlogModel blog)
    {
        RestRequest restRequest = new RestRequest($"/api/Blog", Method.Post);
        restRequest.AddJsonBody(blog);
        await _restClient.ExecuteAsync(restRequest);
        return Redirect("/Blog");
    }

    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        RestRequest restRequest = new RestRequest($"api/Blog/{id}", Method.Get);
        var response = await _restClient.GetAsync(restRequest);
        if(!response.IsSuccessStatusCode)
        {
            return Redirect("/Blog");
        }
        var jsonStr = response.Content;
        BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr!)!;
        return View("BlogEdit", model);
    }

    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdateAsync(int id, BlogModel blog)
    {
        HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
        RestRequest restRequest = new RestRequest($"/api/Blog/{id}", Method.Put);
        restRequest.AddJsonBody(blog);
        await _restClient.ExecuteAsync(restRequest);
        return Redirect("/Blog");
    }

    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(int id)
    {
        await _restClient.DeleteAsync($"/api/Blog/{id}");
        RestRequest restRequest = new RestRequest($"/api/Blog/{id}", Method.Delete);
        return Redirect("/Blog");
    }
}
