using SSDLDotNetCore.ConsoleAppPagination.Db;
using SSDLDotNetCore.ConsoleAppPagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.ConsoleAppPagination.Pagination;

public class PaginationExample
{
    AppDBContext _db = new AppDBContext();

    public void Run()
    {
        Generate(391);
    }

    private void Create(string title, string author, string content)
    {
        var item = new BlogModel
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        _db.Blogs.Add(item);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Creating Successful." : "Creating Failed.";
        Console.WriteLine(message);
    }

    public void Generate(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int rowNo = i + 1;
            Create("Title" + rowNo, "Author" + rowNo, "Content" + rowNo);
        }
    }
}
