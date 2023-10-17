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
    public class ProdottiUsiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: ProdottiUsi
        public ActionResult Index()
        {
            var prodottiUsi = db.ProdottiUsi.Include(p => p.Prodotti).Include(p => p.UsiDisponibili);
            return View(prodottiUsi.ToList());
        }

        // GET: ProdottiUsi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdottiUsi prodottiUsi = db.ProdottiUsi.Find(id);
            if (prodottiUsi == null)
            {
                return HttpNotFound();
            }
            return View(prodottiUsi);
        }

        // GET: ProdottiUsi/Create
        public ActionResult Create()
        {
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo");
            ViewBag.IdUsi = new SelectList(db.UsiDisponibili, "IdUsi", "Descrizione");
            return View();
        }

        // POST: ProdottiUsi/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdottiUsi,IdUsi,IdProdotti")] ProdottiUsi prodottiUsi)
        {
            if (ModelState.IsValid)
            {
                db.ProdottiUsi.Add(prodottiUsi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", prodottiUsi.IdProdotti);
            ViewBag.IdUsi = new SelectList(db.UsiDisponibili, "IdUsi", "Descrizione", prodottiUsi.IdUsi);
            return View(prodottiUsi);
        }

        // GET: ProdottiUsi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdottiUsi prodottiUsi = db.ProdottiUsi.Find(id);
            if (prodottiUsi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", prodottiUsi.IdProdotti);
            ViewBag.IdUsi = new SelectList(db.UsiDisponibili, "IdUsi", "Descrizione", prodottiUsi.IdUsi);
            return View(prodottiUsi);
        }

        // POST: ProdottiUsi/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProdottiUsi,IdUsi,IdProdotti")] ProdottiUsi prodottiUsi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodottiUsi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", prodottiUsi.IdProdotti);
            ViewBag.IdUsi = new SelectList(db.UsiDisponibili, "IdUsi", "Descrizione", prodottiUsi.IdUsi);
            return View(prodottiUsi);
        }

        // GET: ProdottiUsi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdottiUsi prodottiUsi = db.ProdottiUsi.Find(id);
            if (prodottiUsi == null)
            {
                return HttpNotFound();
            }
            return View(prodottiUsi);
        }

        // POST: ProdottiUsi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdottiUsi prodottiUsi = db.ProdottiUsi.Find(id);
            db.ProdottiUsi.Remove(prodottiUsi);
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
