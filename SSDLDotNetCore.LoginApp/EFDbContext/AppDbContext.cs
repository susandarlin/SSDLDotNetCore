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

