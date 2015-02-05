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
    public class ColorShopsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ColorShops
        public ActionResult Index()
        {
            return View(db.ColorShops.OrderBy(e => e.ShopName).ToList());
        }

        // GET: ColorShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorShop colorShop = db.ColorShops.Find(id);
            if (colorShop == null)
            {
                return HttpNotFound();
            }
            return View(colorShop);
        }

        // GET: ColorShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopId,ShopName")] ColorShop colorShop)
        {
            if (ModelState.IsValid)
            {
                db.ColorShops.Add(colorShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorShop);
        }

        // GET: ColorShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorShop colorShop = db.ColorShops.Find(id);
            if (colorShop == null)
            {
                return HttpNotFound();
            }
            return View(colorShop);
        }

        // POST: ColorShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopId,ShopName")] ColorShop colorShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorShop);
        }

        // GET: ColorShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorShop colorShop = db.ColorShops.Find(id);
            if (colorShop == null)
            {
                return HttpNotFound();
            }
            return View(colorShop);
        }

        // POST: ColorShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorShop colorShop = db.ColorShops.Find(id);
            db.ColorShops.Remove(colorShop);
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
