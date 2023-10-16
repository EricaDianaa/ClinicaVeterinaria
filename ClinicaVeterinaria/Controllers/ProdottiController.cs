﻿using System;
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

        //ViewBag per la liste degli usi da db
        private List<SelectListItem> UsiDisponibili
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<UsiDisponibili> listUsi = db.UsiDisponibili.ToList();
                foreach (UsiDisponibili uso in listUsi)
                {
                    list.Add(new SelectListItem { Text = uso.Descrizione, Value = uso.IdUsi.ToString() });
                }
                return list;
            }
        }

        // GET: Prodotti
        public ActionResult Index()
        {
            List<Prodotti> prodotti = db.Prodotti.ToList();
            //var prodotti = db.Prodotti.Include(p => p.Ditte);
            return View(prodotti.ToList());
        }

        // GET: Prodotti/Details/5
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

        // GET: Prodotti/Create
        public ActionResult Create()
        {
            ViewBag.UsiDisponibili = UsiDisponibili;
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome");
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View();
        }

        // POST: Prodotti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProdotto,Tipo,Nome,Descrizione,IdDitta")] Prodotti prodotti, FormCollection cheks)
        {
            if (ModelState.IsValid)
            {
                List<string> selezione = cheks.GetValues("Selezione")?.ToList();
                foreach (string s in selezione)
                {
                    prodotti.ProdottiUsi.Add(new ProdottiUsi{ IdUsi = Convert.ToInt16(s) });
                }


                db.Prodotti.Add(prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsiDisponibili = UsiDisponibili;
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome", prodotti.IdDitta);
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View(prodotti);
        }

        // GET: Prodotti/Edit/5
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
            ViewBag.UsiDisponibili = UsiDisponibili;
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            return View(prodotti);
        }

        // POST: Prodotti/Edit/5
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
            ViewBag.UsiDisponibili = UsiDisponibili;
            ViewBag.Tipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Medicinale", Value = "Medicinale" },
                new SelectListItem { Text = "Alimentare", Value = "Alimentare" }
            };
            ViewBag.IdDitta = new SelectList(db.Ditte, "IdDitta", "Nome", prodotti.IdDitta);
            return View(prodotti);
        }

        // GET: Prodotti/Delete/5
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

        // POST: Prodotti/Delete/5
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
