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
    public class ApparelController : Controller
    {
        private BudContext db = new BudContext();

        // GET: Apparel
        public ActionResult Index()
        {
            return View(db.Apparels.ToList());
        }

        // GET: Apparel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparel apparel = db.Apparels.Find(id);
            if (apparel == null)
            {
                return HttpNotFound();
            }
            return View(apparel);
        }

        // GET: Apparel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apparel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApparelID,Name,Price,Size,Description")] Apparel apparel)
        {
            if (ModelState.IsValid)
            {
                db.Apparels.Add(apparel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apparel);
        }

        // GET: Apparel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparel apparel = db.Apparels.Find(id);
            if (apparel == null)
            {
                return HttpNotFound();
            }
            return View(apparel);
        }

        // POST: Apparel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApparelID,Name,Price,Size,Description")] Apparel apparel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apparel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apparel);
        }

        // GET: Apparel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparel apparel = db.Apparels.Find(id);
            if (apparel == null)
            {
                return HttpNotFound();
            }
            return View(apparel);
        }

        // POST: Apparel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apparel apparel = db.Apparels.Find(id);
            db.Apparels.Remove(apparel);
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
