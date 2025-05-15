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
    public class Visiting_HoursController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Visiting_Hours
        public ActionResult Index()
        {
            return View(db.Visiting_Hours.ToList());
        }

        // GET: Visiting_Hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiting_Hours visiting_Hours = db.Visiting_Hours.Find(id);
            if (visiting_Hours == null)
            {
                return HttpNotFound();
            }
            return View(visiting_Hours);
        }

        // GET: Visiting_Hours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visiting_Hours/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Start_Time,End_Time")] Visiting_Hours visiting_Hours)
        {
            if (ModelState.IsValid)
            {
                db.Visiting_Hours.Add(visiting_Hours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visiting_Hours);
        }

        // GET: Visiting_Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiting_Hours visiting_Hours = db.Visiting_Hours.Find(id);
            if (visiting_Hours == null)
            {
                return HttpNotFound();
            }
            return View(visiting_Hours);
        }

        // POST: Visiting_Hours/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Start_Time,End_Time")] Visiting_Hours visiting_Hours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiting_Hours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visiting_Hours);
        }

        // GET: Visiting_Hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiting_Hours visiting_Hours = db.Visiting_Hours.Find(id);
            if (visiting_Hours == null)
            {
                return HttpNotFound();
            }
            return View(visiting_Hours);
        }

        // POST: Visiting_Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visiting_Hours visiting_Hours = db.Visiting_Hours.Find(id);
            db.Visiting_Hours.Remove(visiting_Hours);
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
