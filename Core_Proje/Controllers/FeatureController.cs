using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {
            var value = featureManager.TGetByID(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Feature t)
        {
            featureManager.TUpdate(t);
            return RedirectToAction("Index","Default");
        }
        
    }
}
