using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudHarbourV1.DAL;
using BudHarbourV1.Models;

namespace BudHarbourV1.Controllers
{
    public class SaleController : Controller
    {
        private BudContext db = new BudContext();

        // GET: Sale
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Apparel).Include(s => s.Bake).Include(s => s.Customer).Include(s => s.Hydro).Include(s => s.Smoke);
            return View(sales.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            ViewBag.ApparelID = new SelectList(db.Apparels, "ApparelID", "Name");
            ViewBag.BakeID = new SelectList(db.Bakes, "BakeID", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.HydroID = new SelectList(db.Hydros, "HydroID", "Name");
            ViewBag.SmokeID = new SelectList(db.Smokes, "SmokeID", "Name");
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,ApparelID,BakeID,HydroID,SmokeID,CustomerID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApparelID = new SelectList(db.Apparels, "ApparelID", "Name", sale.ApparelID);
            ViewBag.BakeID = new SelectList(db.Bakes, "BakeID", "Name", sale.BakeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sale.CustomerID);
            ViewBag.HydroID = new SelectList(db.Hydros, "HydroID", "Name", sale.HydroID);
            ViewBag.SmokeID = new SelectList(db.Smokes, "SmokeID", "Name", sale.SmokeID);
            return View(sale);
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApparelID = new SelectList(db.Apparels, "ApparelID", "Name", sale.ApparelID);
            ViewBag.BakeID = new SelectList(db.Bakes, "BakeID", "Name", sale.BakeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sale.CustomerID);
            ViewBag.HydroID = new SelectList(db.Hydros, "HydroID", "Name", sale.HydroID);
            ViewBag.SmokeID = new SelectList(db.Smokes, "SmokeID", "Name", sale.SmokeID);
            return View(sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,ApparelID,BakeID,HydroID,SmokeID,CustomerID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApparelID = new SelectList(db.Apparels, "ApparelID", "Name", sale.ApparelID);
            ViewBag.BakeID = new SelectList(db.Bakes, "BakeID", "Name", sale.BakeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sale.CustomerID);
            ViewBag.HydroID = new SelectList(db.Hydros, "HydroID", "Name", sale.HydroID);
            ViewBag.SmokeID = new SelectList(db.Smokes, "SmokeID", "Name", sale.SmokeID);
            return View(sale);
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
