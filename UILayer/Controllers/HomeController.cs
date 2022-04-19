using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INotyfService _notyf;
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger,INotyfService notyf,UserManager<ApplicationUser> userManager)
        {
            _notyf = notyf;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChangeReadedValue(int id)
        {
            var selectedNotification = _notificationManager.GetById(id);
            selectedNotification.isReaded = true;
            _notificationManager.Update(selectedNotification);
            return null;
        }

        public IActionResult SeeAllNotification()
        {
            var currentUser = _userManager.GetUserAsync((ClaimsPrincipal) User).Result;
            var notificationList = _notificationManager.GetListByCurrentUserIdAll(currentUser.Id);
            return View(notificationList);
        }
    }
}