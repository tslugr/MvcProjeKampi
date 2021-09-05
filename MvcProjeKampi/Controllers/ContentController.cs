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
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());

        [HttpGet]
        public ActionResult GetAllContent()
        {
            var values = cm.GetList();

            return View(values);
        }

        [HttpPost]
        public ActionResult GetAllContent(string searchKeyWord)
        {
            var values = cm.GetListBySearch(searchKeyWord);

            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}