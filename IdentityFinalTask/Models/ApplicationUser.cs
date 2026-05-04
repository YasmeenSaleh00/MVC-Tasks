using Microsoft.AspNetCore.Identity;

namespace IdentityFinalTask.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Age { get; set; }
        public string FullName { get; set; }
    }
}
