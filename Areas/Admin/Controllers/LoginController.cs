using LawFirmTemplate.Areas.Admin.ViewModels;
using LawFirmTemplate.Data;
using LawFirmTemplate.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LawFirmTemplate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Context _context;

        public LoginController(SignInManager<IdentityUser> signInManager, Context context)
        {
            _signInManager = signInManager;            
            _context = context;
        }

        public IActionResult Login()
        {
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel userSignInViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignInViewModel.UserName, userSignInViewModel.Password, false, true);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
       
    }
}
