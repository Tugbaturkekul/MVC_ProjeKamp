using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentvalues = cm.GetListByWriter();
            return View(contentvalues);
        }
    }
}