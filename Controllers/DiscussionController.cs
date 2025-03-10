﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinyRockForum.Data;
using ShinyRockForum.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;

//NEW FILE WHY ITS WORKING BUT NOT....I DONT KNOW

namespace ShinyRockForum.Controllers
{
    [Authorize]
    public class DiscussionController : Controller
    {
        private readonly ShinyRockForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DiscussionController(ShinyRockForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Removed discussions/details method

        // GET: Discussions/Index
        [Route("Discussions/Index")]
        public async Task<IActionResult> Index()
        {
            string userID = _userManager.GetUserId(User);

            Console.WriteLine("FETCHING ITEMS");

            var discussions = await _context.Discussion
                .Where(m => m.ApplicationUserId == userID)
                .Include(d => d.Comments)
                .OrderByDescending(d => d.CreateDate)
                .ToListAsync();



            Console.WriteLine("THERE ARE THESE MANY ITEMS" + discussions.Count);

            return View(discussions);
        }

        // GET: Discussions/Edit
        public async Task<IActionResult> Edit(int? id)
        {

            Console.WriteLine("IN EDIT GET");



            if (id == null)
            {
                return NotFound();
            }

            var userID = _userManager.GetUserId(User);
            var discussion = await _context.Discussion
                .Include(d => d.Comments)
                .Where(m => m.ApplicationUserId == userID)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

        // POST: Discussions/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscussionId,Title,Content,ImageFile")] Discussion discussion)
        {

            discussion.ApplicationUserId = _userManager.GetUserId(User);

            if (id != discussion.DiscussionId)
            {
                return NotFound();
            }

            if (discussion.ImageFile != null)
            {
                //set the image filename to a guid
                discussion.ImageFilename = Guid.NewGuid().ToString() + Path.GetExtension(discussion.ImageFile?.FileName);
            }

            if (ModelState.IsValid)
            {

                _context.Update(discussion);
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
            return View(discussion);
        }

        // GET: Discussions/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userID = _userManager.GetUserId(User);

            var discussion = await _context.Discussion
                .Include(d => d.Comments)
                .Where(m => m.ApplicationUserId == userID)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

        // POST: Discussions/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userID = _userManager.GetUserId(User);

            var discussion = await _context.Discussion
                .Where(m => m.ApplicationUserId == userID)
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }
            else
            {
                _context.Discussion.Remove(discussion);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }




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

            discussion.ApplicationUserId = _userManager.GetUserId(User);
            Console.WriteLine(discussion.ApplicationUserId);

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
            

            return View(discussion);
        }


    }
}
