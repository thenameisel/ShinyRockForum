using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShinyRockForum.Models;
using ShinyRockForum.Data;


namespace ShinyRockForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShinyRockForumContext _context;

        public HomeController(ShinyRockForumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussion
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate) 
                .ToListAsync();

            return View(discussions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetDiscussion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion
                .Where(m => m.DiscussionId == id)
                .Include(d => d.Comments.OrderByDescending(d => d.CreateDate))
                .FirstOrDefaultAsync();

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

    }

}
