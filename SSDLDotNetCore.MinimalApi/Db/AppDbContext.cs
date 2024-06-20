using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.MinimalApi.Models;

namespace SSDLDotNetCore.MinimalApi.Db
{
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
}
