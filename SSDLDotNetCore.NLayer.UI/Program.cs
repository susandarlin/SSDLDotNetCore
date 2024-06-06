// See https://aka.ms/new-console-template for more information
using SSDLDotNetCore.NLayer.DataAccess.Models;
using SSDLDotNetCore.RestApiWithNLayer.Features.Blog;

Console.WriteLine("Hello, World!");

BL_Blog bL_Blog = new BL_Blog();
var model = bL_Blog.GetBlogs();

var lst = model.ToList();
foreach (BlogModel item in lst)
{
    Console.WriteLine(item.BlogId);
    Console.WriteLine(item.BlogTitle);
    Console.WriteLine(item.BlogAuthor);
    Console.WriteLine(item.BlogContent);
    Console.WriteLine("------------------------------------------");
}

Console.ReadLine();
