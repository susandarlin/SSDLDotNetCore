using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.BlazorServer.Models;

namespace SSDLDotNetCore.BlazorServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogModel> Blog { get; set; }
    }    
}
