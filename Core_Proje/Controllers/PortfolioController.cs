using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var x = portfolioManager.TGetList();
            return View(x);
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio t)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results=validations.Validate(t);
            if(results.IsValid)
            {
              portfolioManager.TAdd(t);
            }
            else
            {
                foreach(var item in results.Errors) 
                { 
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            
            return View();
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var value = portfolioManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio t)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(t);
            if (results.IsValid)
            {
                portfolioManager.TUpdate(t);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }
            }
            return View();
        }
    }
}
