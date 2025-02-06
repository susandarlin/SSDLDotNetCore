using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSDLDotNetCore.LoginApp.EFDbContext;

namespace SSDLDotNetCore.LoginApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;

        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel user)
        {
            var item = await _db.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
            if (item is null) return View();

            await _db.Logins.AddAsync(new LoginModel
            {
                SessionId = Guid.NewGuid().ToString(),
                UserId = user.Id.ToString(),
                SessionExpired = DateTime.Now.AddMinutes(30)
            });

            await _db.SaveChangesAsync();

            return Redirect("/Home");
        }
    }
}
