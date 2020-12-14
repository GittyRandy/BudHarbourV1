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
    public class BakeController : Controller
    {
        private BudContext db = new BudContext();

        // GET: Bake
        public ActionResult Index()
        {
            return View(db.Bakes.ToList());
        }

        // GET: Bake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bake bake = db.Bakes.Find(id);
            if (bake == null)
            {
                return HttpNotFound();
            }
            return View(bake);
        }

        // GET: Bake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BakeID,Name,Price,Description")] Bake bake)
        {
            if (ModelState.IsValid)
            {
                db.Bakes.Add(bake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bake);
        }

        // GET: Bake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bake bake = db.Bakes.Find(id);
            if (bake == null)
            {
                return HttpNotFound();
            }
            return View(bake);
        }

        // POST: Bake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BakeID,Name,Price,Description")] Bake bake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bake);
        }

        // GET: Bake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bake bake = db.Bakes.Find(id);
            if (bake == null)
            {
                return HttpNotFound();
            }
            return View(bake);
        }

        // POST: Bake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bake bake = db.Bakes.Find(id);
            db.Bakes.Remove(bake);
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
