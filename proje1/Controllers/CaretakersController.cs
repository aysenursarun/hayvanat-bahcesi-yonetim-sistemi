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
    public class CaretakersController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Caretakers
        public ActionResult Index()
        {
            return View(db.Caretakers.ToList());
        }

        // GET: Caretakers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers caretakers = db.Caretakers.Find(id);
            if (caretakers == null)
            {
                return HttpNotFound();
            }
            return View(caretakers);
        }

        // GET: Caretakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caretakers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Gender,Birthdate,Phone,Address,User_ID")] Caretakers caretakers)
        {
            if (ModelState.IsValid)
            {
                db.Caretakers.Add(caretakers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caretakers);
        }

        // GET: Caretakers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers caretakers = db.Caretakers.Find(id);
            if (caretakers == null)
            {
                return HttpNotFound();
            }
            return View(caretakers);
        }

        // POST: Caretakers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Gender,Birthdate,Phone,Address,User_ID")] Caretakers caretakers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caretakers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caretakers);
        }

        // GET: Caretakers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers caretakers = db.Caretakers.Find(id);
            if (caretakers == null)
            {
                return HttpNotFound();
            }
            return View(caretakers);
        }

        // POST: Caretakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caretakers caretakers = db.Caretakers.Find(id);
            db.Caretakers.Remove(caretakers);
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
