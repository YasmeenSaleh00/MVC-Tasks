using System.ComponentModel.DataAnnotations;

namespace Practise_Database_Migration.Models
{
    public class Brand:MainEntity
    {
        [Required(ErrorMessage = "The Name Of Brand Required")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
       
    }
}
