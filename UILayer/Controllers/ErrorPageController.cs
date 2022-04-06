using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project.Controllers
{
    public class ErrorPageController: Controller
    {
        private readonly INotyfService _notyf;

        public ErrorPageController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Error(int code)
        {
            _notyf.Error("Olmayan bir sayfaya gittiniz!");
            return View();
        }
    }
}