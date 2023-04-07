using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_ProjeKamp.Controllers
{
    public class LoginController : Controller
    {
      /*  private string GetHash(string value)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }*/
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
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                TempData["ErrorMessage"] = "Hatalı Kullanıcı Adı veya Şifre Girdiniz";
                return RedirectToAction("Index");
            }
           
        }
    }
}
    
