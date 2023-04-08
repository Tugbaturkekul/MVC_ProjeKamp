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
    public class AbilityController : Controller
    {
        AbilityManager am = new AbilityManager(new EfAbilityDal());
        public ActionResult Index()
        {
            var abilities = am.GetList();
            return View(abilities);
        }
        [HttpGet]
        public ActionResult AddAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbility(Ability p)
        {
            AbilityValidator abilityValidator = new AbilityValidator();
            ValidationResult results = abilityValidator.Validate(p);
            if (results.IsValid)
            {
                am.AbilityAddBL(p);
                return RedirectToAction("Index");
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
        

    }

}
