using System.ComponentModel.DataAnnotations;

namespace SchoolEducationPortal.Services.ProfilePic
{
    public class ProfilePicViewModel
    {
        [Display(Name = "Enter Profile Picture")]
        public string? ProfilePicture { get; set; } = string.Empty;

        public IFormFile? file { get; set; }
    }
}
