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
    public class VenditeController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Vendite
        public ActionResult Index()
        {
            var vendite = db.Vendite.Include(v => v.Utenti);
            return View(vendite.ToList());
        }

        // GET: Vendite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendite vendite = db.Vendite.Find(id);
            if (vendite == null)
            {
                return HttpNotFound();
            }
            return View(vendite);
        }

        // GET: Vendite/Create
        public ActionResult Create()
        {
            if (Session["cart"] == null)
            {
                List<Carrello> carrello = new List<Carrello>();
                Session["cart"] = carrello;
            }
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "CodiceFiscale");
            //return View();
            return PartialView("Create");
        }

        // POST: Vendite/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVendita,IdUtente,DataVendita,NumeroRicetta")] Vendite vendite)
        {
            if (ModelState.IsValid)
            {
                vendite.DataVendita = DateTime.Now;

                if (Session["cart"] == null)
                {
                    return RedirectToAction("CreaCarrello", "Carrello");
                }
                else
                {
                    db.Vendite.Add(vendite);

                    List<Carrello> cart = (List<Carrello>)Session["cart"];
                    foreach (Carrello cartItem in cart)
                    {
                        vendite.Dettagli.Add(new Dettagli
                        {
                            IdProdotto = cartItem.IdProduct,
                            Quantita = cartItem.qta,
                            Prezzo = cartItem.Prezzo,
                        });
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", vendite.IdUtente);
            return View(vendite);
        }

        // GET: Vendite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendite vendite = db.Vendite.Find(id);
            if (vendite == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", vendite.IdUtente);
            return View(vendite);
        }

        // POST: Vendite/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding.
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVendita,IdUtente,DataVendita,NumeroRicetta")] Vendite vendite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", vendite.IdUtente);
            return View(vendite);
        }

        // GET: Vendite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendite vendite = db.Vendite.Find(id);
            if (vendite == null)
            {
                return HttpNotFound();
            }
            return View(vendite);
        }

        // POST: Vendite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendite vendite = db.Vendite.Find(id);
            db.Vendite.Remove(vendite);
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