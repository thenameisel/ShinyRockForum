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
            List<Discussion> discussions = await _context.Discussion
                .OrderByDescending(d => d.CreateDate)
                .Take(20)
                .ToListAsync();

            return View(discussions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

}
