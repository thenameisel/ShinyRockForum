using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShinyRockForum.Data;

namespace ShinyRockForum.Data
{
    public class ShinyRockForumContext : IdentityDbContext<ApplicationUser>
    {
        public ShinyRockForumContext (DbContextOptions<ShinyRockForumContext> options)
            : base(options)
        {
        }

        public DbSet<ShinyRockForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<ShinyRockForum.Models.Comment> Comment { get; set; } = default!;
    }
}
