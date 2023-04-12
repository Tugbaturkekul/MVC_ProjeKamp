using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            //writeridinfo yu mimariye taşı babee
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
          //  ViewBag.d = p;
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
    }
}