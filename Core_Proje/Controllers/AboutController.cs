using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            var value = aboutManager.TGetByID(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About t)
        {
            aboutManager.TUpdate(t);
            return RedirectToAction("Index", "Default");
        }
        
    }
}
