using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class ArmadiettiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Armadietti
        public ActionResult Index()
        {
            return View(db.Armadietti.ToList());
        }

        // GET: Armadietti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadietti armadietti = db.Armadietti.Find(id);
            if (armadietti == null)
            {
                return HttpNotFound();
            }
            return View(armadietti);
        }

        // GET: Armadietti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armadietti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArmadietto,CodiceArmadietto")] Armadietti armadietti)
        {
            if (ModelState.IsValid)
            {
                db.Armadietti.Add(armadietti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armadietti);
        }

        // GET: Armadietti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadietti armadietti = db.Armadietti.Find(id);
            if (armadietti == null)
            {
                return HttpNotFound();
            }
            return View(armadietti);
        }

        // POST: Armadietti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArmadietto,CodiceArmadietto")] Armadietti armadietti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armadietti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armadietti);
        }

        // GET: Armadietti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadietti armadietti = db.Armadietti.Find(id);
            if (armadietti == null)
            {
                return HttpNotFound();
            }
            return View(armadietti);
        }

        // POST: Armadietti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armadietti armadietti = db.Armadietti.Find(id);
            db.Armadietti.Remove(armadietti);
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
