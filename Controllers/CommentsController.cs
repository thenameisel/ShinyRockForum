using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinyRockForum.Data;
using ShinyRockForum.Models;

namespace ShinyRockForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ShinyRockForumContext _context;

        public CommentsController(ShinyRockForumContext context)
        {
            _context = context;
        }

        //removing edit, comments and delete methods, they are not needed
        //removing details, its not needed
        

        // GET: Comments/Create
        public IActionResult Create(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            
            ViewData["DiscussionId"] = id;

            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,DiscussionId")] Comment comment)
        {
            
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;

                _context.Add(comment);
                await _context.SaveChangesAsync();

                return RedirectToAction("GetDiscussion", "Home", new {id = comment.DiscussionId});
            }

            ViewData["DiscussionId"] = comment.DiscussionId;

            return View(comment);
        }

    }
}
