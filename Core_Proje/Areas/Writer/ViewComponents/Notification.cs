﻿using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke(object parameter)
        {
            var vv = announcementManager.TGetList().Take(5).ToList();
            return View(vv);
        }
    }
}
