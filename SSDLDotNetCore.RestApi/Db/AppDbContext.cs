using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.RestApi.Db;
using SSDLDotNetCore.ConsoleApp.Services;
using SSDLDotNetCore.RestApi.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.RestApi.Db
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
