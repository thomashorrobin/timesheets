using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimesheetsWebApp2.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            List<DateTime> mondays = new List<DateTime>();
            DateTime dt = DateTime.Today.AddDays(-45);
            while (dt <= DateTime.Today)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    mondays.Add(dt/*.ToString("yyyyMMdd")*/);
                }
                dt = dt.AddDays(1);
            }
            ViewBag.Mondays = new SelectList(mondays, mondays.OrderByDescending(e => e).First());
            List<ColorShop> shops = db.ColorShops.ToList();
            ViewBag.Shops = new SelectList(db.ColorShops, "ShopId", "ShopName");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(int Shops, DateTime Mondays)
        {
            //return Content("ColorShopId: " + Shops + " WeekStarting: " + Mondays);
            return RedirectToAction("NewTimesheet", "TimeSheets", new { ColorShopId = Shops, WeekStarting = Mondays });
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }
    }
}