using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.ConsoleAppPagination.Models;
using SSDLDotNetCore.ConsoleAppPagination.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.ConsoleAppPagination.Db;

public class AppDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
    }
    
    public DbSet<BlogModel> Blogs { get; set; }
}
