using Microsoft.AspNetCore.Identity;
namespace Study_Identity_in_MVC.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string ProfilePicturePath { get; set; }

    }
}
