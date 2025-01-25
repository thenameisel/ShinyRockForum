using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShinyRockForum.Models;

namespace ShinyRockForum.Data
{
    public class ShinyRockForumContext : DbContext
    {
        public ShinyRockForumContext (DbContextOptions<ShinyRockForumContext> options)
            : base(options)
        {
        }

        public DbSet<ShinyRockForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<ShinyRockForum.Models.Comment> Comment { get; set; } = default!;
    }
}
