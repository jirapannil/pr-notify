using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNotify.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PRNotify.Controllers
{
    public class NotificationController : Controller
    {
        private readonly AppDbContext _context;
        public NotificationController(AppDbContext context) => _context = context;

        // GET: /Notification
        public async Task<IActionResult> Index()
        {
            // สมมติว่ามีระบบ login และ user id ปัจจุบัน
            int currentUserId = 1; // Replace this with actual user id from session
            var notifications = await _context.Notifications
                .Where(n => n.UserId == currentUserId)
                .OrderByDescending(n => n.CreateDate)
                .ToListAsync();
            return View(notifications);
        }

        // POST: /Notification/MarkAsRead/5
        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return NotFound();
            notification.IsRead = true;
            _context.Update(notification);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}