using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
        // GET: Contact
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);

            return View(contactvalues);
        }

        public PartialViewResult PartialMessageMenu()
        {
            var contactList = cm.GetList();
            ViewBag.contactCount = contactList.Count();
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