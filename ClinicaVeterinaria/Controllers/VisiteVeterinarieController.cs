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
    public class VisiteVeterinarieController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: VisiteVeterinarie
        public ActionResult Index()
        {
            var visiteVeterinarie = db.VisiteVeterinarie.Include(v => v.AnimaliRicoverati);
            return View(visiteVeterinarie.ToList());
        }

        // GET: VisiteVeterinarie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteVeterinarie visiteVeterinarie = db.VisiteVeterinarie.Find(id);
            if (visiteVeterinarie == null)
            {
                return HttpNotFound();
            }
            return View(visiteVeterinarie);
        }

        // GET: VisiteVeterinarie/Create
        public ActionResult Create()
        {
            ViewBag.IdAnimale = new SelectList(db.AnimaliRicoverati, "IdAnimali", "Nome");
            return View();
        }

        // POST: VisiteVeterinarie/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVisite,Data,IdAnimale,ObiettivoEsame,Descrizione")] VisiteVeterinarie visiteVeterinarie)
        {
            if (ModelState.IsValid)
            {
                db.VisiteVeterinarie.Add(visiteVeterinarie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimale = new SelectList(db.AnimaliRicoverati, "IdAnimali", "Nome", visiteVeterinarie.IdAnimale);
            return View(visiteVeterinarie);
        }

        // GET: VisiteVeterinarie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteVeterinarie visiteVeterinarie = db.VisiteVeterinarie.Find(id);
            if (visiteVeterinarie == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnimale = new SelectList(db.AnimaliRicoverati, "IdAnimali", "Nome", visiteVeterinarie.IdAnimale);
            return View(visiteVeterinarie);
        }

        // POST: VisiteVeterinarie/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVisite,Data,IdAnimale,ObiettivoEsame,Descrizione")] VisiteVeterinarie visiteVeterinarie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiteVeterinarie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimale = new SelectList(db.AnimaliRicoverati, "IdAnimali", "Nome", visiteVeterinarie.IdAnimale);
            return View(visiteVeterinarie);
        }

        // GET: VisiteVeterinarie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteVeterinarie visiteVeterinarie = db.VisiteVeterinarie.Find(id);
            if (visiteVeterinarie == null)
            {
                return HttpNotFound();
            }
            return View(visiteVeterinarie);
        }

        // POST: VisiteVeterinarie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisiteVeterinarie visiteVeterinarie = db.VisiteVeterinarie.Find(id);
            db.VisiteVeterinarie.Remove(visiteVeterinarie);
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
