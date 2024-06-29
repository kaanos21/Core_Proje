using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
           [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        
        ExperienceManager experienceManager = new ExperienceManager(new EfExpreinceDal());
        public IActionResult Index()
        {
            var value = experienceManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Expreince t)
        {
            experienceManager.TAdd(t);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.TGetByID(id);
            experienceManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            var value = experienceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditExperience(Expreince t)
        {
            experienceManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
