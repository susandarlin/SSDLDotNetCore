﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSDLDotNetCore.MvcApiCall.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SSDLDotNetCore.MvcPagination.Controllers;

public class BlogHttpClientController : Controller
{
    private readonly HttpClient _httpClient;

    public BlogHttpClientController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
    {
        BlogResponseModel model = new BlogResponseModel();
        var response = await _httpClient.GetAsync($"api/Blog/{pageNo}/{pageSize}");
        if (response.IsSuccessStatusCode)
        {
            var jsonStr = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;
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
        HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
        await _httpClient.PostAsync("/api/blog", content);
        return Redirect("/Blog");
    }

    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var response = await _httpClient.GetAsync($"/api/blog/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return Redirect("/Blog");
        }
        var jsonStr = await response.Content.ReadAsStringAsync();
        BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
        return View("BlogEdit", model);
    }

    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdateAsync(int id, BlogModel blog)
    {
        HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
        await _httpClient.PutAsync($"/api/Blog/{id}", content);
        return Redirect("/Blog");
    }

    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(int id)
    {
        await _httpClient.DeleteAsync($"/api/Blog/{id}");
        return Redirect("/Blog");
    }
}
