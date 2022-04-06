using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models.LoginViewModel;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotyfService _notyf;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,INotyfService notyf)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel userData)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userData.Email, userData.Password, userData.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _notyf.Success("Başarıyla giriş yaptınız");
                    var loggedUser = await _userManager.FindByEmailAsync(userData.Email);
                    var kullaniciRolleri = await _userManager.GetRolesAsync(loggedUser);
                    if(kullaniciRolleri[0]=="admin")
                    {

                        return RedirectToAction("Index", "Admin");
                    }
                    else if(kullaniciRolleri[0]=="designer")
                    {

                        return RedirectToAction("Index", "Designer");
                    }
                    else if(kullaniciRolleri[0]=="marketing")
                    {

                        return RedirectToAction("Index", "Marketing");
                    }
                    else if(kullaniciRolleri[0]=="ops")
                    {

                        return RedirectToAction("Index", "Ops");
                    }
                    else if(kullaniciRolleri[0]=="customer")
                    {

                        return RedirectToAction("Index", "Customer");
                    }
                    

                }
                _notyf.Error("Giriş başarısız");
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(userData);
        }
        
        public async Task<IActionResult> ConfirmMail(string token, string email)
        {
           
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _notyf.Error("Böyle bir kullanıcı yok!");
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                _notyf.Success("Mailiniz başarıyla onaylanmıştır.");
                return View();
            }

            return View();

        }

        public async Task<IActionResult> Logout()
        {
            
            await _signInManager.SignOutAsync();
            _notyf.Success("Başarıyla çıkış yaptınız");
            return RedirectToAction("Index","Account");
        }

        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}