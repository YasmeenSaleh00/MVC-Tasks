using System.ComponentModel.DataAnnotations;

namespace Practise_Database_Migration.Models
{
    public class Product:MainEntity
    {
        [Required(ErrorMessage = "The Name Of Product Required")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public Category? Category { get; set; }
        public Brand? Brand { get; set; }

    }
}
