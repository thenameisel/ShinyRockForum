using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ShinyRockForum.Models;
using ShinyRockForum.Data;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace ShinyRockForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShinyRockForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ShinyRockForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            Console.WriteLine("FETCHING ITEMS");

            var discussions = await _context.Discussion
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate) 
                .ToListAsync();

            Console.WriteLine("THERE ARE THESE MANY ITEMS" + discussions.Count);

            return View(discussions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Profile(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            
            return View(user);
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
