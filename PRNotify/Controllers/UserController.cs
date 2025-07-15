using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNotify.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PRNotify.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context) => _context = context;

        // GET: /User
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Title)
                .ToListAsync();
            return View(users);
        }

        // GET: /User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            ViewBag.Roles = _context.Roles.ToList();
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Titles = _context.Titles.ToList();
            return View(user);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId) return NotFound();
            if (ModelState.IsValid)
            {
                user.UpdateDate = DateTime.Now;
                _context.Update(user);
                await _context.SaveChangesAsync();
                // log update
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = _context.Roles.ToList();
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Titles = _context.Titles.ToList();
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Status = UserStatus.Inactive;
                user.UpdateDate = DateTime.Now;
                _context.Update(user);
                await _context.SaveChangesAsync();
                // log delete
            }
            return RedirectToAction(nameof(Index));
        }
    }
}