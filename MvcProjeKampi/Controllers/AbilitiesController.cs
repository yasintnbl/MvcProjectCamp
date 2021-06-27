using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AbilitiesController : Controller
    {
        AbilityManager abm = new AbilityManager(new EfAbilityDal());
        // GET: Abilities
        public ActionResult Index()
        {
            var result = abm.GetList();
            return View(result);
        }
    }
}