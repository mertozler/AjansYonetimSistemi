using System;
using System.Collections.Generic;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.ViewComponents
{
    public class NavbarAnnouncement:ViewComponent
    {
        private AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementRepository());
        private readonly ILogger<NavbarAnnouncement> _logger;

        public NavbarAnnouncement(ILogger<NavbarAnnouncement> logger)
        {
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            List<Announcement> announcements = new List<Announcement>();
            try
            {
                announcements = _announcementManager.GetList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            
            return View(announcements);
        }
    }
}