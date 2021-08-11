using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AbilityCardsController : Controller
    {
        AbilityManager abm = new AbilityManager(new EfAbilityDal());
        AbilityValidator av = new AbilityValidator();
        // GET: AbilityCards
        public ActionResult Index()
        {
            var result = abm.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbility(Ability ability)
        {
            ValidationResult result = av.Validate(ability);
            if (result.IsValid)
            {
                abm.AbilityAdd(ability);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditAbility(int id)
        {
            List<SelectListItem> valueAbility = (from x in abm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AbiltyName,
                                                     Value = x.AbiltyID.ToString()
                                                 }).ToList();
            ViewBag.vlc = valueAbility;
            var abilityValue = abm.GetById(id);
            return View(abilityValue);
        }
        [HttpPost]
        public ActionResult EditAbility(Ability ability)
        {
            abm.AbilityUpdate(ability);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbility(int id)
        {
            var abilityValue = abm.GetById(id);

            abm.AbilityDelete(abilityValue);
            return RedirectToAction("Index");
        }
    }
}