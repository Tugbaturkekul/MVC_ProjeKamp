using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string adminUserName = (string)Session["AdminUserName"];
            var messagelist = mm.GetListInbox(adminUserName);
            return View(messagelist);
        }
        [Authorize]
        public ActionResult Sendbox(string p)
        {
            string adminUserName = (string)Session["AdminUserName"];
            var messagelist = mm.GetListSendbox(adminUserName);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetail(int id)
        {
            var values = mm.GetByID(id);
            //view görüntülendiyse mesaj okunmuştur
            if (!values.IsRead)
            {
                values.IsRead = true;
                mm.MessageUpdate(values);
            }
            return View(values);
          
        }
        public ActionResult GetSendboxMessageDetail(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(p);
                return RedirectToAction("Sendbox");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult IsRead(int id) 
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsRead)
            {
                messageValue.IsRead = false;
            }
            else
            {
                messageValue.IsRead = true;
            }
            mm.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }
    }
}