using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using ShinyRockForum.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyRockForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "A Name is required.")]
        [PersonalData]
        public string Name { get; set; } = string.Empty;

        [PersonalData]
        public string Location { get; set; } = string.Empty;

        [PersonalData]
        public string Bio { get; set; } = string.Empty;

        [PersonalData]
        public string ImageFilename { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}