using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SSDLDotNetCore.LoginMiddlewareAppWithCookie.EFDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<LoginModel> Login { get; set; }
}

[Table("Tbl_Middleware_User")]
public class UserModel
{

    [Key]
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

[Table("Tbl_Login")]
public class LoginModel
{
    [Key]
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? SessionId { get; set; }
    public DateTime? SessionExpired { get; set; }
}
