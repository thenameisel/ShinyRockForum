using System;
using System.ComponentModel.DataAnnotations;

namespace ShinyRockForum.Models
{
    public class Discussion
    {
        //Discussion Id
        public int DiscussionId { get; set; }

        //Title
        [Required(ErrorMessage = "A description is required.")]
        public string Title { get; set; } = string.Empty;
        //Content
        [Required(ErrorMessage = "A description is required.")]
        public string Content { get; set; } = string.Empty;

        //ImageFilename
        public string? ImageFilename { get; set; } = string.Empty;

        //CreateDate
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
