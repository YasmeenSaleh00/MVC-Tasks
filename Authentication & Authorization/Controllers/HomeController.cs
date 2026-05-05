using Practise_Database_Migration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Practise_Database_Migration.Controllers
{
    public class HomeController : Controller
    {
        private readonly SimpleEcommarceDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,SimpleEcommarceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            //using tuples
            var categories = _context.Categories.ToList();
            var brands = _context.Brands.ToList();
            var products = _context.Products.ToList();
            var model = new Tuple<List<Category> , List<Brand>,List<Product>>(categories, brands,products);    
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
