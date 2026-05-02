using Microsoft.AspNetCore.Mvc;

namespace Study_Identity_in_MVC.Controllers
{
    public class AdminDashBordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
