using System.ComponentModel.DataAnnotations;

namespace E_Commaerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImagePath {  get; set; }
    }
}
