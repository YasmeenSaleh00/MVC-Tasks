using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Authentication_and_Authorization_Task.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Range(18,100)]
        public int Age { get; set; }
    }
}
