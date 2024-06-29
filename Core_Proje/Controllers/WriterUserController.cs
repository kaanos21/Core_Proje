using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ListUser()
        {
            var value = JsonConvert.SerializeObject(userManager.TGetList());
            return Json(value);
        }
        private static List<class0> liste = new List<class0>()
        {
            new class0 { Id = 1,Ad="Ali"},
            new class0 { Id = 1,Ad="Ayşe"},
            new class0 { Id = 1,Ad="Esra"}
        };
        public class class0
        {
            public int Id { get; set; }
            public string Ad { get; set; }
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser p) 
        {
            userManager.TAdd(p);
            var v = JsonConvert.SerializeObject(p);
            return Json(v);
        }
    }
}
