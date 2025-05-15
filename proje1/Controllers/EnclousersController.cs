using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proje1.Models;

namespace proje1.Controllers
{
    public class EnclousersController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Enclousers
        public ActionResult Index()
        {
            var enclousers = db.Enclousers.Include(e => e.Visiting_Hours);
            return View(enclousers.ToList());
        }

        // GET: Enclousers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enclousers enclousers = db.Enclousers.Find(id);
            if (enclousers == null)
            {
                return HttpNotFound();
            }
            return View(enclousers);
        }

        // GET: Enclousers/Create
        public ActionResult Create()
        {
            ViewBag.Visiting_Hours_ID = new SelectList(db.Visiting_Hours, "ID", "ID");
            return View();
        }

        // POST: Enclousers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Capacity,Visiting_Hours_ID")] Enclousers enclousers)
        {
            if (ModelState.IsValid)
            {
                db.Enclousers.Add(enclousers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Visiting_Hours_ID = new SelectList(db.Visiting_Hours, "ID", "ID", enclousers.Visiting_Hours_ID);
            return View(enclousers);
        }

        // GET: Enclousers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enclousers enclousers = db.Enclousers.Find(id);
            if (enclousers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Visiting_Hours_ID = new SelectList(db.Visiting_Hours, "ID", "ID", enclousers.Visiting_Hours_ID);
            return View(enclousers);
        }

        // POST: Enclousers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Capacity,Visiting_Hours_ID")] Enclousers enclousers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enclousers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Visiting_Hours_ID = new SelectList(db.Visiting_Hours, "ID", "ID", enclousers.Visiting_Hours_ID);
            return View(enclousers);
        }

        // GET: Enclousers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enclousers enclousers = db.Enclousers.Find(id);
            if (enclousers == null)
            {
                return HttpNotFound();
            }
            return View(enclousers);
        }

        // POST: Enclousers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enclousers enclousers = db.Enclousers.Find(id);
            db.Enclousers.Remove(enclousers);
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
