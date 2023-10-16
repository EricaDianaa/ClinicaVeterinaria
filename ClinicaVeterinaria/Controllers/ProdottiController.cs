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
    public class ProdottiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Prodottis
        public ActionResult Index()
        {
            var prodotti = db.Prodotti.Include(p => p.Ditte);
            return View(prodotti.ToList());
        }

        // GET: Prodottis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodotti.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        // GET: Prodottis/Create
        public ActionResult Create()
        {
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome");
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View();
        }

        // POST: Prodottis/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdotto,Tipo,Nome,Descrizione,IdDitta")] Prodotti prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Prodotti.Add(prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome", prodotti.IdDitta);
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View(prodotti);
        }

        // GET: Prodottis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodotti.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome", prodotti.IdDitta);
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View(prodotti);
        }

        // POST: Prodottis/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProdotto,Tipo,Nome,Descrizione,IdDitta")] Prodotti prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome", prodotti.IdDitta);
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View(prodotti);
        }

        // GET: Prodottis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodotti.Find(id);
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        // POST: Prodottis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodotti prodotti = db.Prodotti.Find(id);
            db.Prodotti.Remove(prodotti);
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