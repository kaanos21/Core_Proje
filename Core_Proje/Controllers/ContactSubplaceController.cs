using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var value = contactManager.TGetByID(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact t)
        {
            contactManager.TUpdate(t);
            return RedirectToAction("Index", "Default");
        }
    }
}
