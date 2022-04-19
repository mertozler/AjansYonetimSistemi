using System;
using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Project.ViewComponents
{
    public class NavbarNotification:ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        private readonly UserManager<ApplicationUser> _userManager;

        public NavbarNotification(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var currentUser = _userManager.GetUserAsync((ClaimsPrincipal) User).Result;
            var notificationList = _notificationManager.GetListByCurrentUserId(currentUser.Id);
            return View(notificationList);
        }
    }
}