using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
       
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            Context c = new Context();
            ViewBag.Heading = c.Headings.Select(x => x.HeadingID).Count();

            ViewBag.Content = c.Contents.Select(x => x.ContentID).Count();

            ViewBag.Writer = c.Writers.Select(x => x.WriterID).Count();

            ViewBag.Message = c.Messages.Select(x => x.MessageID).Count();
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult HomeContact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult HomeContact(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAdd(contact);
            return PartialView("HomeContact");
        }
       
    }
}