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
    public class Cassetto_ProdottiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Cassetto_Prodotti
        public ActionResult Index()
        {
            var cassetto_Prodotti = db.Cassetto_Prodotti.Include(c => c.Cassetti).Include(c => c.Prodotti);
            return View(cassetto_Prodotti.ToList());
        }

        // GET: Cassetto_Prodotti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cassetto_Prodotti cassetto_Prodotti = db.Cassetto_Prodotti.Find(id);
            if (cassetto_Prodotti == null)
            {
                return HttpNotFound();
            }
            return View(cassetto_Prodotti);
        }

        // GET: Cassetto_Prodotti/Create
        public ActionResult Create()
        {
            ViewBag.IdCassetto = new SelectList(db.Cassetti, "IdCassetto", "IdCassetto");
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Nome");
            return View();
        }

        // POST: Cassetto_Prodotti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCassettoProdotti,IdCassetto,IdProdotti")] Cassetto_Prodotti cassetto_Prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Cassetto_Prodotti.Add(cassetto_Prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCassetto = new SelectList(db.Cassetti, "IdCassetto", "IdCassetto", cassetto_Prodotti.IdCassetto);
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", cassetto_Prodotti.IdProdotti);
            return View(cassetto_Prodotti);
        }

        // GET: Cassetto_Prodotti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cassetto_Prodotti cassetto_Prodotti = db.Cassetto_Prodotti.Find(id);
            if (cassetto_Prodotti == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCassetto = new SelectList(db.Cassetti, "IdCassetto", "IdCassetto", cassetto_Prodotti.IdCassetto);
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", cassetto_Prodotti.IdProdotti);
            return View(cassetto_Prodotti);
        }

        // POST: Cassetto_Prodotti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCassettoProdotti,IdCassetto,IdProdotti")] Cassetto_Prodotti cassetto_Prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cassetto_Prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCassetto = new SelectList(db.Cassetti, "IdCassetto", "IdCassetto", cassetto_Prodotti.IdCassetto);
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Tipo", cassetto_Prodotti.IdProdotti);
            return View(cassetto_Prodotti);
        }

        // GET: Cassetto_Prodotti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cassetto_Prodotti cassetto_Prodotti = db.Cassetto_Prodotti.Find(id);
            if (cassetto_Prodotti == null)
            {
                return HttpNotFound();
            }
            return View(cassetto_Prodotti);
        }

        // POST: Cassetto_Prodotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cassetto_Prodotti cassetto_Prodotti = db.Cassetto_Prodotti.Find(id);
            db.Cassetto_Prodotti.Remove(cassetto_Prodotti);
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
