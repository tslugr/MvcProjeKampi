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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm= new MessageManager(new EfMessageDal());
  
       MessageValidator messagevalidators = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageinlist = mm.GetListInbox(p);
            return View(messageinlist);
        }
        public ActionResult Sendbox(string p)
        {
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
        public ActionResult NewMessage(Message p,string button)
        {
            ValidationResult results =messagevalidators.Validate(p);
            if (button == "draft")
            {

                results = messagevalidators.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Now;
                    p.SenderMail = "admin@gmail.com";
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
                    p.SenderMail = "admin@gmail.com";
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

            //    if (results.IsValid)
            //    {
            //        p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //       mm.MessageAddBL(p);
            //        return RedirectToAction("Sendbox");
            //    }
            //    else
            //    {
            //        foreach (var item in results.Errors)
            //        {
            //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //        }
            //    }
            //    return View();
            }

        public ActionResult Draft(string p)
        {
            var sendList = mm.GetSendbox(p);
            var draftList = sendList.FindAll(x => x.isDraft == true);
            return View(draftList);
        }
        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = mm.GetByID(id);

            return View(Values);
        }

        public ActionResult Read()
        {
            var deger = mm.GetReadList();
            return View(deger);
        }

        public ActionResult UnRead()
        {
            var deger = mm.GetUnReadList();
            return View(deger);
        }

    }
}