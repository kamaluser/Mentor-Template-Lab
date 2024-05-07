using MentorInClass.Areas.Manage.ViewModels;
using MentorInClass.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MentorInClass.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CreateAdmin() 
        {
            AppUser admin = new AppUser
            {
                UserName = "kamal",
                FullName = "Salam123"
            };

            var result = await _userManager.CreateAsync(admin, "Kamal123");
            return Json(result);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            AppUser admin = await _userManager.FindByNameAsync(loginVM.UserName);

            if (admin == null)
            {
                ModelState.AddModelError("","UserName or Password is Incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, false, false);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is Incorrect!");
                return View(); 
            }

            return RedirectToAction("index", "dashboard");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
