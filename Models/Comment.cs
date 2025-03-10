﻿using ShinyRockForum.Data;

namespace ShinyRockForum.Models
{
    public class Comment
    {
        //int CommentId
        public int CommentId { get; set; }

        //string Content
        public string Content { get; set; } = string.Empty;
        //datatime CreateDate
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //int DiscussionId(foreign key)
        public int DiscussionId { get; set; }

        // Navigation property back to Discussion
        public Discussion? Discussion { get; set; }

        // Foreign key for creator
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!
    }
}
