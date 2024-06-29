using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var vv=messageManager.TGetList();
            return View(vv);
        }
        public IActionResult DeleteContact(int id)
        {
            var vv=messageManager.TGetByID(id);
            messageManager.TDelete(vv);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var vv= messageManager.TGetByID(id);
            return View(vv);
        }
    }
}
