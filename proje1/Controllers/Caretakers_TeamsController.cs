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
    public class Caretakers_TeamsController : Controller
    {
        private ProjectEntities1 db = new ProjectEntities1();

        // GET: Caretakers_Teams
        public ActionResult Index()
        {
            var caretakers_Teams = db.Caretakers_Teams.Include(c => c.Animal_Types).Include(c => c.Caretakers);
            return View(caretakers_Teams.ToList());
        }

        // GET: Caretakers_Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers_Teams caretakers_Teams = db.Caretakers_Teams.Find(id);
            if (caretakers_Teams == null)
            {
                return HttpNotFound();
            }
            return View(caretakers_Teams);
        }

        // GET: Caretakers_Teams/Create
        public ActionResult Create()
        {
            ViewBag.Animal_Type_ID = new SelectList(db.Animal_Types, "ID", "Name");
            ViewBag.Caretaker_ID = new SelectList(db.Caretakers, "ID", "Name");
            return View();
        }

        // POST: Caretakers_Teams/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Caretaker_ID,Animal_Type_ID")] Caretakers_Teams caretakers_Teams)
        {
            if (ModelState.IsValid)
            {
                db.Caretakers_Teams.Add(caretakers_Teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Animal_Type_ID = new SelectList(db.Animal_Types, "ID", "Name", caretakers_Teams.Animal_Type_ID);
            ViewBag.Caretaker_ID = new SelectList(db.Caretakers, "ID", "Name", caretakers_Teams.Caretaker_ID);
            return View(caretakers_Teams);
        }

        // GET: Caretakers_Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers_Teams caretakers_Teams = db.Caretakers_Teams.Find(id);
            if (caretakers_Teams == null)
            {
                return HttpNotFound();
            }
            ViewBag.Animal_Type_ID = new SelectList(db.Animal_Types, "ID", "Name", caretakers_Teams.Animal_Type_ID);
            ViewBag.Caretaker_ID = new SelectList(db.Caretakers, "ID", "Name", caretakers_Teams.Caretaker_ID);
            return View(caretakers_Teams);
        }

        // POST: Caretakers_Teams/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Caretaker_ID,Animal_Type_ID")] Caretakers_Teams caretakers_Teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caretakers_Teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Animal_Type_ID = new SelectList(db.Animal_Types, "ID", "Name", caretakers_Teams.Animal_Type_ID);
            ViewBag.Caretaker_ID = new SelectList(db.Caretakers, "ID", "Name", caretakers_Teams.Caretaker_ID);
            return View(caretakers_Teams);
        }

        // GET: Caretakers_Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caretakers_Teams caretakers_Teams = db.Caretakers_Teams.Find(id);
            if (caretakers_Teams == null)
            {
                return HttpNotFound();
            }
            return View(caretakers_Teams);
        }

        // POST: Caretakers_Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caretakers_Teams caretakers_Teams = db.Caretakers_Teams.Find(id);
            db.Caretakers_Teams.Remove(caretakers_Teams);
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
