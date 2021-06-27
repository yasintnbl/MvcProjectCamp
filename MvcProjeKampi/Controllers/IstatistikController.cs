using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
       
        // GET: Istatistik
        public ActionResult Index()
        {
            var category = c.Categories.Count();
            ViewBag.Gorev1 = category;

            var heading = c.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.Gorev2 = heading;


            var writer = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Gorev3 = writer;

            var maxHeading = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.Gorev4 = maxHeading;

            var categoryTrueFalse = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.Gorev5 = categoryTrueFalse;


            return View();
        }
        
    }
}