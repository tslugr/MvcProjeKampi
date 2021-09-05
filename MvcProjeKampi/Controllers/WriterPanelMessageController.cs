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
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());

        MessageValidator messagevalidators = new MessageValidator();
      
        public ActionResult Inbox()
        {

          string p = (string)Session["WriterMail"];
            var messageinlist = mm.GetListInbox(p);
            return View(messageinlist);
        }
        public ActionResult Sendbox()
        {
          string  p = (string)Session["WriterMail"];
            var messagesendlist = mm.GetSendbox(p);
            return View(messagesendlist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageRead = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageRead = true;
            mm.MessageUpdate(values);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p, string button)

        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidators.Validate(p);
            if (button == "draft")
            {

                results = messagevalidators.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Now;
                    p.SenderMail = sender;
                    p.isDraft = true;
                    mm.MessageAddBL(p);
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
            else if (button == "save")
            {
                results = messagevalidators.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Now;
                    p.SenderMail = sender;
                    p.isDraft = false;
                    mm.MessageAddBL(p);
                    return RedirectToAction("SendBox");
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

        public PartialViewResult _PartialMessageMenu()
        {
      
            //var listResult = mm.GetSendbox();
            //var sendList = listResult.FindAll(x => x.isDraft == false);
            //ViewBag.sendCount = sendList.Count();
            //var listResult2 = mm.GetListInbox();
            //ViewBag.inboxCount = listResult2.Count();

            //var drafList = listResult.FindAll(x => x.isDraft == true);
            //ViewBag.draftCount = drafList.Count();
            var deger5 = mm.GetReadList();
            ViewBag.sayi5 = deger5.Count();

            var deger6 = mm.GetUnReadList();
            ViewBag.sayi6 = deger6.Count();

            return PartialView();
        }
    }
}