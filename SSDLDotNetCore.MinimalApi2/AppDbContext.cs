using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.MinimalApi2.Models;

namespace SSDLDotNetCore.MinimalApi2;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BlogModel> blog { get; set; }
}
