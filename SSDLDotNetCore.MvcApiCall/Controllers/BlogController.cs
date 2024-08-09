using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SSDLDotNetCore.MvcApiCall.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SSDLDotNetCore.MvcApiCall.Controllers;

public class BlogController : Controller
{
    private readonly IBlogApi _blogApi;

    public BlogController(IBlogApi blogApi)
    {
        _blogApi = blogApi;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex(int pageNo = 1,  int pageSize = 10)
    {
        var model = await _blogApi.GetBlogs(pageNo, pageSize);
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
        await _blogApi.CreateBlog(blog);
        return Redirect("/Blog");
    }

    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var model = await _blogApi.GetBlog(id);
        return View("BlogEdit", model);
    }

    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
    {
        await _blogApi.PatchBlog(id, blog);
        return Redirect("/Blog");
    }

    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(int id)
    {
        await _blogApi.DeleteBlog(id);
        return Redirect("/Blog");
    }
}
