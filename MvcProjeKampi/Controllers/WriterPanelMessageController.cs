using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
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
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, string parameter)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = mv.Validate(message);
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = sender;
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (parameter == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = sender;
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }

        public ActionResult Draft()
        {
            var result = mm.IsDraft();
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result = mm.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            mm.MessageUpdate(result);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            var readMessage = mm.GetAll().Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            var unReadMessage = mm.GetAllUnRead();
            return View(unReadMessage);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var draftValues = mm.GetById(id);
            return View(draftValues);
        }
    }
}
