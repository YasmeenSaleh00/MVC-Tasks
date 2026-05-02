using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Study_Identity_in_MVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (!string.IsNullOrEmpty(role.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
