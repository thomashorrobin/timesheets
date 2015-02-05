using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimesheetsWebApp2;

namespace TimesheetsWebApp2.Controllers
{
    public class WeeklyTotalsController : Controller
    {
        private Model1 db = new Model1();

        // GET: WeeklyTotals by TimesheetId
        public ActionResult Index(int TimesheetId)
        {
            var weeklyTotals = db.WeeklyTotals.Where(e => e.TimeSheetId == TimesheetId).Include(w => w.Employee);
            TimeSheet ts = db.TimeSheets.Single(s => s.TimeSheetId == TimesheetId);
            ViewBag.Title = "Employee detail for " + ts.ColorShop.ShopName + " Colorshop";
            ViewBag.SubTitle = "Week starting " + ts.WeekStarting.ToLongDateString();
            return View(weeklyTotals.OrderByDescending(e => e.WeekStarting).ToList());
        }

        public ActionResult EditWeek(int ShopId, DateTime WeekStarting, int EmployeeId)
        {
            ViewBag.Title = "Edit timesheet for " + db.Employees.Find(EmployeeId).EmployeeName + " from " + WeekStarting.ToShortDateString() + " to " + WeekStarting.AddDays(6).ToShortDateString();
            ViewBag.SubTitle = db.ColorShops.Find(ShopId).ShopName;
            return View(new EmployeeWeek(EmployeeId,WeekStarting,ShopId).Hours);
        }

        // GET: WeeklyTotals by EmployeeId
        public ActionResult ListTotalsByEmployee(int EmployeeId)
        {
            var weeklyTotals = db.WeeklyTotals.Where(e => e.EmployeeId == EmployeeId).Include(w => w.Employee);
            ViewBag.Title = "Timesheets for " + db.Employees.Find(EmployeeId).EmployeeName;
            return View("Index", weeklyTotals.OrderByDescending(e => e.WeekStarting).ToList());
        }

        // GET: WeeklyTotals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyTotal weeklyTotal = db.WeeklyTotals.Find(id);
            if (weeklyTotal == null)
            {
                return HttpNotFound();
            }
            return View(weeklyTotal);
        }

        // GET: WeeklyTotals/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: WeeklyTotals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeSheetId,EmployeeId,RegularMinutesTotal,OvertimeMinutesTotal,AnnualLeaveMinutes,SickLeaveMinutes,OtherLeaveMinutes,WeekStarting,ShopId")] WeeklyTotal weeklyTotal)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyTotals.Add(weeklyTotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", weeklyTotal.EmployeeId);
            return View(weeklyTotal);
        }

        // GET: WeeklyTotals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyTotal weeklyTotal = db.WeeklyTotals.Find(id);
            if (weeklyTotal == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", weeklyTotal.EmployeeId);
            return View(weeklyTotal);
        }

        // POST: WeeklyTotals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeSheetId,EmployeeId,RegularMinutesTotal,OvertimeMinutesTotal,AnnualLeaveMinutes,SickLeaveMinutes,OtherLeaveMinutes,WeekStarting,ShopId")] WeeklyTotal weeklyTotal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyTotal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", weeklyTotal.EmployeeId);
            return View(weeklyTotal);
        }

        // GET: WeeklyTotals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyTotal weeklyTotal = db.WeeklyTotals.Find(id);
            if (weeklyTotal == null)
            {
                return HttpNotFound();
            }
            return View(weeklyTotal);
        }

        // POST: WeeklyTotals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeeklyTotal weeklyTotal = db.WeeklyTotals.Find(id);
            db.WeeklyTotals.Remove(weeklyTotal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
