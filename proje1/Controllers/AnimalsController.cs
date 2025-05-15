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
    public class AnimalsController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.Animal_Types).Include(a => a.Enclousers);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.AnimalType_ID = new SelectList(db.Animal_Types, "ID", "Name");
            ViewBag.Enclosure_ID = new SelectList(db.Enclousers, "ID", "Name");
            return View();
        }

        // POST: Animals/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Gender,Enclosure_ID,AnimalType_ID")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalType_ID = new SelectList(db.Animal_Types, "ID", "Name", animals.AnimalType_ID);
            ViewBag.Enclosure_ID = new SelectList(db.Enclousers, "ID", "Name", animals.Enclosure_ID);
            return View(animals);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalType_ID = new SelectList(db.Animal_Types, "ID", "Name", animals.AnimalType_ID);
            ViewBag.Enclosure_ID = new SelectList(db.Enclousers, "ID", "Name", animals.Enclosure_ID);
            return View(animals);
        }

        // POST: Animals/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Gender,Enclosure_ID,AnimalType_ID")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalType_ID = new SelectList(db.Animal_Types, "ID", "Name", animals.AnimalType_ID);
            ViewBag.Enclosure_ID = new SelectList(db.Enclousers, "ID", "Name", animals.Enclosure_ID);
            return View(animals);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animals animals = db.Animals.Find(id);
            db.Animals.Remove(animals);
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
