using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_ProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {   
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName);
            if (adminuserinfo != null && adminuserinfo.AdminPassword == (p.AdminPassword))
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                TempData["ErrorMessage"] = "Hatalı Kullanıcı Adı veya Şifre Girdiniz";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail);
            if (writeruserinfo != null && writeruserinfo.WriterPassword== (p.WriterPassword))
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                TempData["ErrorMessage"] = "Hatalı Kullanıcı Adı veya Şifre Girdiniz";
                return RedirectToAction("WriterLogin");
            }
        
        }

    }
}


