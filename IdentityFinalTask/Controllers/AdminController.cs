using IdentityFinalTask.Areas.Identity.Pages.Account;
using IdentityFinalTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityFinalTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //ضفت depndncy injection
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
          
        }
        public IActionResult Index()
        {

            return View();
        }
        //    الي رول تبعهم  user عشان اجيب كل المساخدمين
        public async Task<IActionResult> ListUser()
        {
           var users = await _userManager.GetUsersInRoleAsync("User");
            return View(users);
            

        }
        //add admins
        [HttpGet]
        public IActionResult AddNewAdmin()
        {
            // نرسل موديل فارغ للـ View لتجنب خطأ الـ Null Reference
            return View(new RegisterModel.InputModel());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewAdmin(RegisterModel.InputModel model)
        {
            // نستخدم model.Input لأن الـ View تعتمد على InputModel داخل RegisterModel
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FullName = model.FullName,
                        Age = model.Age,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                }
            }

            // إذا فشلنا، نعيد نفس الموديل للـ View لإظهار الأخطاء
            return View(model);
        }
    
}
}
