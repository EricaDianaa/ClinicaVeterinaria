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
    [Authorize(Roles = "Admin")]
    public class UsiDisponibiliController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: UsiDisponibili
        public ActionResult Index()
        {
            return View(db.UsiDisponibili.ToList());
        }

        // GET: UsiDisponibili/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsiDisponibili usiDisponibili = db.UsiDisponibili.Find(id);
            if (usiDisponibili == null)
            {
                return HttpNotFound();
            }
            return View(usiDisponibili);
        }

        // GET: UsiDisponibili/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsiDisponibili/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsi,Descrizione")] UsiDisponibili usiDisponibili)
        {
            if (ModelState.IsValid)
            {
                db.UsiDisponibili.Add(usiDisponibili);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usiDisponibili);
        }

        // GET: UsiDisponibili/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsiDisponibili usiDisponibili = db.UsiDisponibili.Find(id);
            if (usiDisponibili == null)
            {
                return HttpNotFound();
            }
            return View(usiDisponibili);
        }

        // POST: UsiDisponibili/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsi,Descrizione")] UsiDisponibili usiDisponibili)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usiDisponibili).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usiDisponibili);
        }

        // GET: UsiDisponibili/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsiDisponibili usiDisponibili = db.UsiDisponibili.Find(id);
            if (usiDisponibili == null)
            {
                return HttpNotFound();
            }
            return View(usiDisponibili);
        }

        // POST: UsiDisponibili/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsiDisponibili usiDisponibili = db.UsiDisponibili.Find(id);
            db.UsiDisponibili.Remove(usiDisponibili);
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
