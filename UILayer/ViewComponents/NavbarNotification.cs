using System;
using System.Collections.Generic;
using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.ViewComponents
{
    public class NavbarNotification:ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<NavbarNotification> _logger;
        public NavbarNotification(UserManager<ApplicationUser> userManager,ILogger<NavbarNotification> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            List<Notification> notificationList = new List<Notification>();
            try
            {
                var currentUser = _userManager.GetUserAsync((ClaimsPrincipal) User).Result;
                notificationList = _notificationManager.GetListByCurrentUserId(currentUser.Id);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return View(notificationList);
        }
    }
}