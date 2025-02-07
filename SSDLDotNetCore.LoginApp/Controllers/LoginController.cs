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

            var sessionId = Guid.NewGuid().ToString();
            var sessionExpired = DateTime.Now.AddSeconds(40);

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = sessionExpired;
            Response.Cookies.Append("UserId", item.Id.ToString(), cookie);
            Response.Cookies.Append("SessionId", sessionId, cookie);

            await _db.Logins.AddAsync(new LoginModel
            {
                SessionId = sessionId,
                UserId = item.Id.ToString(),
                SessionExpired = sessionExpired
            });

            await _db.SaveChangesAsync();

            return Redirect("/Home");
        }
    }
}
