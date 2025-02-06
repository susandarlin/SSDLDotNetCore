using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSDLDotNetCore.LoginApp.EFDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<LoginModel> Logins { get; set; }
    public DbSet<UserModel> Users { get; set; }
}

[Table("Tbl_Login")]
public class LoginModel
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string SessionId { get; set; }
    public DateTime SessionExpired { get; set; }
}

[Table("Tbl_User")]
public class UserModel
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}


