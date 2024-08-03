using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSDLDotNetCore.RestApi.Db;
using SSDLDotNetCore.RestApi.Models;

namespace SSDLDotNetCore.RestApi.Controllers
{
    // https://localhost:3000 => domain url
    // api/blog => endpoint

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //private readonly AppDbContext _context;
        ////private readonly AppDbContext _context = new AppDbContext();

        //public BlogController()
        //{
        //    _context = new AppDbContext();
        //}

        // Dependency Injection

        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        [HttpGet("PageNo/{pageNo}/pageSize/{pageSize}")]
        public IActionResult Read(int pageNo, int pageSize)
        {
            int rowCount = _context.Blogs.Count();

            int pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
                pageCount++;

            if (pageNo > pageCount)
                return BadRequest(new { Message = "Invalid PageNo." });

            var lst = _context.Blogs
                .OrderByDescending(x => x.BlogId)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();            

            BlogResponseModel model = new();
            model.Data = lst;
            model.PageNo = pageNo;
            model.PageSize = pageSize;
            model.PageCount = pageCount;
            //model.IsEndOfPage = pageNo == pageCount;

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            // update object
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            // update one by one
            var item = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle)) 
            { 
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}
