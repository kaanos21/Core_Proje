using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p = "admin@gmail.com";
            var vv = writerMessageManager.GetListReceiverMessage(p);
            return View(vv);
        }
        public IActionResult SenderMessageList()
        {
            string p = "admin@gmail.com";
            var vv = writerMessageManager.GetListSenderMessage(p);
            return View(vv);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var vv = writerMessageManager.TGetByID(id);
            return View(vv);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var vv = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(vv);
            if (vv.Receiver == "admin@gmail.com")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("SenderMessageList");
            }
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage t)
        {
            t.Sender = "admin@gmail.com";
            t.SenderName = "Admin";
            t.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c=new Context();
            var usennamesurname=c.Users.Where(x=>x.Email==t.Receiver).Select(x=>x.Name + " "+ x.Surname).FirstOrDefault();
            t.ReceiverName = usennamesurname;
            writerMessageManager.TAdd(t);
            return RedirectToAction("SenderMessageList");
        }
    }
}
