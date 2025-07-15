using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNotify.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PRNotify.Controllers
{
    public class CalendarController : Controller
    {
        private readonly AppDbContext _context;
        public CalendarController(AppDbContext context) => _context = context;

        // GET: /Calendar
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Calendar/GetEvents
        public async Task<JsonResult> GetEvents()
        {
            var events = await _context.Activities
                .Where(a => a.RecordStatus == RecordStatus.Active)
                .Select(a => new {
                    id = a.ActivityId,
                    title = a.ActivityName,
                    start = a.ActivityDate.ToString("yyyy-MM-dd"),
                    status = a.Status.ToString()
                }).ToListAsync();
            return Json(events);
        }
    }
}