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
    public class SmokeController : Controller
    {
        private BudContext db = new BudContext();

        // GET: Smoke
        public ActionResult Index()
        {
            return View(db.Smokes.ToList());
        }

        // GET: Smoke/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoke smoke = db.Smokes.Find(id);
            if (smoke == null)
            {
                return HttpNotFound();
            }
            return View(smoke);
        }

        // GET: Smoke/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smoke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmokeID,Name,Price,Description")] Smoke smoke)
        {
            if (ModelState.IsValid)
            {
                db.Smokes.Add(smoke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smoke);
        }

        // GET: Smoke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoke smoke = db.Smokes.Find(id);
            if (smoke == null)
            {
                return HttpNotFound();
            }
            return View(smoke);
        }

        // POST: Smoke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmokeID,Name,Price,Description")] Smoke smoke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smoke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smoke);
        }

        // GET: Smoke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoke smoke = db.Smokes.Find(id);
            if (smoke == null)
            {
                return HttpNotFound();
            }
            return View(smoke);
        }

        // POST: Smoke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smoke smoke = db.Smokes.Find(id);
            db.Smokes.Remove(smoke);
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
