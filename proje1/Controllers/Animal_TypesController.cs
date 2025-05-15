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
    public class Animal_TypesController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Animal_Types
        public ActionResult Index()
        {
            return View(db.Animal_Types.ToList());
        }

        // GET: Animal_Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Types animal_Types = db.Animal_Types.Find(id);
            if (animal_Types == null)
            {
                return HttpNotFound();
            }
            return View(animal_Types);
        }

        // GET: Animal_Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal_Types/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Animal_Types animal_Types)
        {
            if (ModelState.IsValid)
            {
                db.Animal_Types.Add(animal_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal_Types);
        }

        // GET: Animal_Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Types animal_Types = db.Animal_Types.Find(id);
            if (animal_Types == null)
            {
                return HttpNotFound();
            }
            return View(animal_Types);
        }

        // POST: Animal_Types/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Animal_Types animal_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal_Types);
        }

        // GET: Animal_Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Types animal_Types = db.Animal_Types.Find(id);
            if (animal_Types == null)
            {
                return HttpNotFound();
            }
            return View(animal_Types);
        }

        // POST: Animal_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal_Types animal_Types = db.Animal_Types.Find(id);
            db.Animal_Types.Remove(animal_Types);
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
