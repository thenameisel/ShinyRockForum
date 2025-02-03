using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinyRockForum.Data;
using ShinyRockForum.Models;


namespace ShinyRockForum.Controllers
{
    public class DiscussionsController : Controller
    {
        private readonly ShinyRockForumContext _context;

        public DiscussionsController(ShinyRockForumContext context)
        {
            _context = context;
        }

        // GET: Discussions - Removing, do not need discussion index and Home
        //Removed delete and edit methods

       

        // GET: Discussions/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Discussions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscussionId,Title,Content,ImageFile")] Discussion discussion)
        {
            //set the create date to now
            discussion.CreateDate = DateTime.Now;

            if (discussion.ImageFile != null)
            {
                //set the image filename to a guid
                discussion.ImageFilename = Guid.NewGuid().ToString() + Path.GetExtension(discussion.ImageFile?.FileName);
            }

            if (ModelState.IsValid)
            {
                _context.Add(discussion);
                await _context.SaveChangesAsync();

                if (discussion.ImageFile != null)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", discussion.ImageFilename);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await discussion.ImageFile.CopyToAsync(fileStream);
                    }

                }
                return RedirectToAction("Index", "Home");
            }
            else { Console.WriteLine("BANANA"); }

            return View(discussion);
        }

        
    }
}
