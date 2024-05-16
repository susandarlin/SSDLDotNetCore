﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SSDLDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_Blog;

        public BlogController()
        {
            _bl_Blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bl_Blog.GetBlogs();
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _bl_Blog.CreateBlog(blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _bl_Blog.GetBlog(id);
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
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var result = _bl_Blog.UpdateBlog(id, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            // update one by one
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            var result = _bl_Blog.PatchBlog(id, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            var result = _bl_Blog.DeleteBlog(id);
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}
