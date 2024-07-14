using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.MvcApp2.Models;

namespace SSDLDotNetCore.MvcApp2.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
    //}
    public DbSet<BlogModel> Blogs { get; set; }
}
