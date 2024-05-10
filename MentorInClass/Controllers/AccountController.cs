using MentorInClass.Models;
using MentorInClass.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace MentorInClass.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var existUser = await _userManager.FindByEmailAsync(model.Email);
            if (existUser!=null)
            {
                ModelState.AddModelError("","This Email is already Registered!");
                return View(model);
            }

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("",err.Description);
                }
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("index","home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel model, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect!");
                return View();
            }

            return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
