using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.BlazorServerApp.Models;

namespace SSDLDotNetCore.BlazorServerApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
