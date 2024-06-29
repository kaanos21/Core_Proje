using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class TestimonialsController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var vv=testimonialManager.TGetList();
            return View(vv);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var vv=testimonialManager.TGetByID(id);
            testimonialManager.TDelete(vv);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var value = testimonialManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial t)
        {
            testimonialManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
