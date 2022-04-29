using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Utils;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models.LoginViewModel;
using Project.Models.ResetPasswordViewModel;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly INotyfService _notyf;
        private readonly ILogger<CustomerController> _logger;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,INotyfService notyf,ILogger<CustomerController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notyf = notyf;
            _logger = logger;
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var user = _userManager.FindByEmailAsync(email).Result;

                if (user == null || !(_userManager.
                        IsEmailConfirmedAsync(user).Result))
                {
                    ViewBag.Message = "Şifrenizi sıfırlarken bir sorun oluştu! Mail adresinizi kontrol edip tekrardan deneyiniz";
                    return View("ForgotPassword");
                }

                var token = _userManager.
                    GeneratePasswordResetTokenAsync(user).Result;

                var resetLink = Url.Action("ResetPassword", 
                    "Account", new { token = token }, 
                    protocol: HttpContext.Request.Scheme);

                MailService sendMail = new MailService();
                sendMail.SendMailWithReceiverMailContextAndSubject(email,"Şifrenizi sıfırlamak için linke <a href=" +
                                                                         resetLink + ">tıklayınız</a>","Şifre Sıfırlama Talebiniz Alınmıştır");

                // code to email the above link
                // see the earlier article

                ViewBag.Message = "Şifre sıfırlama linkiniz mail adresinize gönderilmiştir!";
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
            }
            
            return View("ForgotPassword");
        }
        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel data)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                var user = _userManager.
                    FindByEmailAsync(data.Email).Result;

                result = _userManager.ResetPasswordAsync
                    (user, data.Token,data.Password).Result;
                
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
            }
            if (result.Succeeded)
            {
                ViewBag.Message = "Şifreniz başarıyla sıfırlanmıştır.! Lütfen yeni şifrenizle giriş yapınız.";
                return View("ResetPassword");
            }
            else
            {
                ViewBag.Message = "Şifreniz sıfırlanırken bir sorun yaşandı!";
                return View("ResetPassword");
            }
            
        }
    }
}