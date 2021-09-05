using DataAccessLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()//asıl view oluşturulacak action result
        {
            return View();
        }

        public ActionResult WriterListLineChart()
        {
            return View();
        }

        public ActionResult HeadingListColumnChart()
        {
            return View();
        }

        #region Mimarisiz Kategori icerisindeki Baslik Listesi Grafigi
        public ActionResult CategoryChart() //köprü görevi gören action result view oluşturulmayacak
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet); //Kategory islemleri icin kullanilan bir yazim komutu
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Gezi",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 3
            });
            return ct;
        }
        #endregion

        // Yazarlarin Baslik Sayisi Listesi \\

        #region Mimarili Yazar Baslik Sayisi Listesi Grafigi

        public ActionResult WriterListChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterClass> WriterList()
        {
            List<WriterClass> writerClasses = new List<WriterClass>();
            using (var context = new Context())
            {
                writerClasses = context.Writers.Select(x => new WriterClass
                {
                    WriterName = x.WriterName,
                    WriterCount = x.Headings.Count()
                }).ToList();
            }
            return writerClasses;
        }

        #endregion

        // Basliklarin Icerik Sayisi Listesi \\

        #region Mimarili Baslik  Icerik Sayisi Listesi Grafigi

        public ActionResult HeadingListChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> headingClasses = new List<HeadingClass>();
            using (var context = new Context())
            {
                headingClasses = context.Headings.Select(x => new HeadingClass
                {
                    HeadingName = x.HeadingName,
                    HeadingCount = x.Contents.Count()
                }).ToList();
            }

            return headingClasses;
        }

        #endregion
    }
}
