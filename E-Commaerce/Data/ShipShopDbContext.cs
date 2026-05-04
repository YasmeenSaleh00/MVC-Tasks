using E_Commaerce.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Commaerce.Data
{
    public class ShipShopDbContext: DbContext
    {
        public ShipShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

    }
}
