using SSDLDotNetCore.ConsoleAppPagination.Db;
using SSDLDotNetCore.ConsoleAppPagination.Pagination;

//PaginationExample paginationExample = new PaginationExample();
//paginationExample.Run();

AppDBContext db = new AppDBContext();
int pageSize = 10;

int rowCount = db.Blogs.Count();

int pageCount = rowCount / pageSize;
Console.WriteLine("Current Page Count " + pageCount);

if(rowCount % pageSize > 0)
    pageCount++;
Console.WriteLine("Current Page Count " + pageCount);