using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSDLDotNetCore.LoginApp.EFDbContext;

public class AppDbContext
{
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
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}


