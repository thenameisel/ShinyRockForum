using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShinyRockForum.Models;

namespace ShinyRockForum.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

}
