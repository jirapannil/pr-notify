using Microsoft.AspNetCore.Mvc;
using PRNotify.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PRNotify.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            // load dropdowns for title, department, etc.
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // hash password, set status, etc.
                user.Status = UserStatus.Active;
                user.CreateDate = DateTime.Now;
                user.UpdateDate = DateTime.Now;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                // log registration
                return RedirectToAction("Login");
            }
            // reload dropdowns
            return View(user);
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        // ... implement Login logic, log logins, etc.
    }
}