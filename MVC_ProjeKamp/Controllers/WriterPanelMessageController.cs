using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
    
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context c = new Context();
        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
           
            return PartialView();
        }
        public ActionResult GetInboxMessageDetail(int id)
        {

            var values = mm.GetByID(id);
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
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
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
            //okundu butonunu true/false yaparak vt a kaydeder
            var messagevalue = mm.GetByID(id);
            if (messagevalue.IsRead)
                messagevalue.IsRead = false;
            else
                messagevalue.IsRead = true;
            mm.MessageUpdate(messagevalue);
            return RedirectToAction("Inbox");
        }
        
    }
}
   
