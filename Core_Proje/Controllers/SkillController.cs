﻿ using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill t)
        {
            skillManager.TAdd(t);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var value=skillManager.TGetByID(id);
            skillManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var value=skillManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill t)
        {
            skillManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
