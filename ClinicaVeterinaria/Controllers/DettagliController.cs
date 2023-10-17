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
    public class DettagliController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Dettagli
        public ActionResult Index()
        {
            var dettagli = db.Dettagli.Include(d => d.Prodotti).Include(d => d.Vendite);
            return View(dettagli.ToList());
        }

        // GET: Dettagli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            return View(dettagli);
        }

        // GET: Dettagli/Create
        public ActionResult Create()
        {
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome");
            ViewBag.IdVendita = new SelectList(db.Vendite, "IdVendita", "NumeroRicetta");
            return View();
        }

        // POST: Dettagli/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDettaglio,IdProdotto,Quantita,IdVendita,Prezzo")] Dettagli dettagli)
        {
            if (ModelState.IsValid)
            {
                db.Dettagli.Add(dettagli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.IdProdotto);
            ViewBag.IdVendita = new SelectList(db.Vendite, "IdVendita", "NumeroRicetta", dettagli.IdVendita);
            return View(dettagli);
        }

        // GET: Dettagli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.IdProdotto);
            ViewBag.IdVendita = new SelectList(db.Vendite, "IdVendita", "NumeroRicetta", dettagli.IdVendita);
            return View(dettagli);
        }

        // POST: Dettagli/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDettaglio,IdProdotto,Quantita,IdVendita,Prezzo")] Dettagli dettagli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dettagli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagli.IdProdotto);
            ViewBag.IdVendita = new SelectList(db.Vendite, "IdVendita", "NumeroRicetta", dettagli.IdVendita);
            return View(dettagli);
        }

        // GET: Dettagli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dettagli dettagli = db.Dettagli.Find(id);
            if (dettagli == null)
            {
                return HttpNotFound();
            }
            return View(dettagli);
        }

        // POST: Dettagli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dettagli dettagli = db.Dettagli.Find(id);
            db.Dettagli.Remove(dettagli);
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
