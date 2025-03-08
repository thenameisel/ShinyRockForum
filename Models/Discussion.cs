using ShinyRockForum.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? ImageFilename { get; set; } //Nullable

        //File storage
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; }

        //CreateDate
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        //navigation property
        public ICollection<Comment>? Comments { get; set; } //Nullable

        // Foreign key for creator
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!


    }
}
