using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        Context c = new Context();
        // GET: Contact
        
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["WriterMail"];
            var contacts = cm.GetList().Count();
            ViewBag.contact = contacts;

            var result = mm.GetListSendbox(p).Count();
            ViewBag.result = result;

                
            var result2 = mm.GetListInbox(p).Count();
            ViewBag.result2 = result2;

            var draft = mm.GetAll().Where(x => x.IsDraft == true).Count();
            ViewBag.draft = draft;


            var readMessage = mm.GetAll().Where(x => x.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetAllUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
           
        }
    }
}