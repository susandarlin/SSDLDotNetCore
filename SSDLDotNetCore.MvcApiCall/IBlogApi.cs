﻿using Refit;
using SSDLDotNetCore.MvcApiCall.Models;

namespace SSDLDotNetCore.MvcApiCall;

public interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blog/{pageNo}/{pageSize}")]
    Task<BlogResponseModel> GetBlogs(int pageNo, int pageSize);

    [Get("/api/blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogModel blog);

    [Put("/api/blog/{id}")]
    Task<string> UpdateBlog(int id, BlogModel blog);

    [Patch("/api/blog/{id}")]
    Task<string> PatchBlog(int id, BlogModel blog);

    [Delete("/api/blog/{id}")]
    Task<string> DeleteBlog(int id);
}
