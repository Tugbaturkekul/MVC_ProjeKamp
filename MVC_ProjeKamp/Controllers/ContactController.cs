using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        Context c = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {

            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactPartial()
        {
            int totalAdminMessageCount = c.Contacts.Count();
            ViewBag.AdminGelenMesajSayisi = totalAdminMessageCount;
            int totalInboxMessageCount = c.Messages.Count();
            ViewBag.GelenMesajSayisi = totalInboxMessageCount;

            return PartialView();
        }
    }
}