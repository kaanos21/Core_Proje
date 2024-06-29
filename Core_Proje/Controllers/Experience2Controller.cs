using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExpreinceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var value = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(value);
        }
        [HttpPost]
        public IActionResult AddExperience(Expreince p)
        {
            experienceManager.TAdd(p);
            var v = JsonConvert.SerializeObject(p);
            return Json(v);
        }
        public IActionResult GetById(int id) 
        {
            var v=experienceManager.TGetByID(id);
            var value=JsonConvert.SerializeObject(v);
            return View(value);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            return NoContent();
        }

    }
}
