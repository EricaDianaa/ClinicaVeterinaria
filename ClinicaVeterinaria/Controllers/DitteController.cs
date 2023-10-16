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
    public class DitteController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Dittes
        public ActionResult Index()
        {
            return View(db.Ditte.ToList());
        }

        // GET: Dittes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ditte ditte = db.Ditte.Find(id);
            if (ditte == null)
            {
                return HttpNotFound();
            }
            return View(ditte);
        }

        // GET: Dittes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dittes/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDitta,Nome,Recapito,Indirizzo")] Ditte ditte)
        {
            if (ModelState.IsValid)
            {
                db.Ditte.Add(ditte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ditte);
        }

        // GET: Dittes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ditte ditte = db.Ditte.Find(id);
            if (ditte == null)
            {
                return HttpNotFound();
            }
            return View(ditte);
        }

        // POST: Dittes/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDitta,Nome,Recapito,Indirizzo")] Ditte ditte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ditte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ditte);
        }

        // GET: Dittes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ditte ditte = db.Ditte.Find(id);
            if (ditte == null)
            {
                return HttpNotFound();
            }
            return View(ditte);
        }

        // POST: Dittes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ditte ditte = db.Ditte.Find(id);
            db.Ditte.Remove(ditte);
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