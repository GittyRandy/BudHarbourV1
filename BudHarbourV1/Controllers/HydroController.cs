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
    public class HydroController : Controller
    {
        private BudContext db = new BudContext();

        // GET: Hydro
        public ActionResult Index()
        {
            return View(db.Hydros.ToList());
        }

        // GET: Hydro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hydro hydro = db.Hydros.Find(id);
            if (hydro == null)
            {
                return HttpNotFound();
            }
            return View(hydro);
        }

        // GET: Hydro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hydro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HydroID,Name,Price,Description")] Hydro hydro)
        {
            if (ModelState.IsValid)
            {
                db.Hydros.Add(hydro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hydro);
        }

        // GET: Hydro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hydro hydro = db.Hydros.Find(id);
            if (hydro == null)
            {
                return HttpNotFound();
            }
            return View(hydro);
        }

        // POST: Hydro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HydroID,Name,Price,Description")] Hydro hydro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hydro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hydro);
        }

        // GET: Hydro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hydro hydro = db.Hydros.Find(id);
            if (hydro == null)
            {
                return HttpNotFound();
            }
            return View(hydro);
        }

        // POST: Hydro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hydro hydro = db.Hydros.Find(id);
            db.Hydros.Remove(hydro);
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
