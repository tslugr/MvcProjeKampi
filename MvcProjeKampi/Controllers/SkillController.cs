using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm= new SkillManager(new EfSkillDal());
        ITalentManager tm = new ITalentManager(new EfTalentDal());
        public ActionResult Index()
        {
         
            var skillValues = tm.GetList();
           
            return View(skillValues);
           
        }

        public ActionResult SkillDetails(int id)
        {
            var skildetails = tm.GetByID(id);

            return View(skildetails);

        }
    }
}