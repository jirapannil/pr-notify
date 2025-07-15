using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRNotify.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PRNotify.Controllers
{
    public class ActivityController : Controller
    {
        private readonly AppDbContext _context;
        public ActivityController(AppDbContext context) => _context = context;

        // GET: /Activity
        public async Task<IActionResult> Index()
        {
            var activities = await _context.Activities
                .Include(a => a.User)
                .Include(a => a.ActivityType)
                .ToListAsync();
            return View(activities);
        }

        // GET: /Activity/Create
        public IActionResult Create()
        {
            ViewBag.ActivityTypes = _context.ActivityTypes.ToList();
            return View();
        }

        // POST: /Activity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Status = ActivityStatus.pending;
                activity.RecordStatus = RecordStatus.Active;
                activity.CreateDate = DateTime.Now;
                activity.UpdateDate = DateTime.Now;
                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();
                // Notify to admin/communication group here
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActivityTypes = _context.ActivityTypes.ToList();
            return View(activity);
        }

        // POST: /Activity/ChangeStatus/5
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, ActivityStatus status)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            activity.Status = status;
            if (status == ActivityStatus.in_progress)
                activity.StatusInProgress = DateTime.Now;
            if (status == ActivityStatus.completed)
                activity.StatusCompleted = DateTime.Now;
            activity.UpdateDate = DateTime.Now;
            _context.Update(activity);
            await _context.SaveChangesAsync();
            // log change
            return Ok();
        }
    }
}