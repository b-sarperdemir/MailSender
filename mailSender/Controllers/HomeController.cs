using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mailSender.Dal;
using mailSender.Models;

namespace mailSender.Controllers
{
    public class HomeController : Controller
    {
        private Helpers hlp;
        
        public HomeController()
        {
            hlp = new Helpers();
        }
        [HttpPost]
        public JsonResult SendMailList(int[] idlist, string subject, string body)
        {
            hlp.emailGonder(subject, idlist, body);
            return Json(true);
        }

        public ActionResult MailList()
        {
            List<mailList> data = hlp.getMailList();
            return View(data);
        }

        public JsonResult DeleteMailList(int id)
        {
            bool sonuc = hlp.deleteMailList(id);
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddMailList(string email, string detail)
        {
            mailList data = new mailList()
            {
                email = email,
                detail = detail
            };
            bool sonuc = hlp.addMailList(data);
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}