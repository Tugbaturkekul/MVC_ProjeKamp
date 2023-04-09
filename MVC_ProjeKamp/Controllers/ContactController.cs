﻿using BusinessLayer.Concrete;
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
     
        ContactManager cm = new ContactManager(new EfContactDal());
       MessageManager mm = new MessageManager(new EfMessageDal());
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
            ViewBag.AdminGelenMesajSayisi = cm.GetList().Count;
            string adminUserName = (string)Session["AdminUserName"];
            ViewBag.GelenMesajSayisi = mm.GelenMesajSayisi(adminUserName);    
            return PartialView();
        }
    }
}