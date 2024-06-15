using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSDLDotNetCore.ConsoleApp.Services;
using SSDLDotNetCore.RestApi.Db;
using SSDLDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace SSDLDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        //private readonly DapperService _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);

        // Using Dependency Injection
        private readonly DapperService _dapperService;

        public BlogDapper2Controller(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var query = "select * from Tbl_Blog";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            var lst = _dapperService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent])
                            VALUES
                            (@BlogTitle
                            ,@BlogAuthor
                            ,@BlogContent)";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, blog);

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            blog.BlogId = id;
            var query = @"UPDATE [dbo].[Tbl_Blog]
                        SET [BlogTitle] = @BlogTitle
                        ,[BlogAuthor] = @BlogAuthor
                        ,[BlogContent] = @BlogContent
                        WHERE BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, blog);

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var conditions = string.Empty;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
            }
            if (conditions.Length == 0)
            {
                return NotFound("No data to update.");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;

            var query = $@"UPDATE [dbo].[Tbl_Blog]
                        SET {conditions}
                        WHERE BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, blog);

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var query = @"delete from tbl_blog where BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, new BlogModel { BlogId = id });

            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }

        public BlogModel FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();

            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        }
    }
}
