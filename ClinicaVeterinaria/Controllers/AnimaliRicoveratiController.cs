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
    public class AnimaliRicoveratiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        public ActionResult Index()
        {
            var animaliRicoverati = db.AnimaliRicoverati.Include(a => a.Tipologia1).Include(a => a.Utenti);
            return View(animaliRicoverati.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimaliRicoverati animaliRicoverati = db.AnimaliRicoverati.Find(id);
            if (animaliRicoverati == null)
            {
                return HttpNotFound();
            }
            return View(animaliRicoverati);
        }

        public ActionResult Create()
        {
            ViewBag.Tipologia = new SelectList(db.Tipologia, "IdTipologia", "Nome");
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimaliRicoverati animaliRicoverati, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                if (foto != null && foto.ContentLength > 0)
                {
                    animaliRicoverati.Foto = foto.FileName;
                    string pathToSave = Server.MapPath("~/Content/ImgProgetto/") + foto.FileName;
                    foto.SaveAs(pathToSave);
                }
                if(animaliRicoverati.NumeroMicrochip == null)
                {
                    animaliRicoverati.NumeroMicrochip = "L'animale non possiede alcun microchip";
                }
                db.AnimaliRicoverati.Add(animaliRicoverati);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            ViewBag.Tipologia = new SelectList(db.Tipologia, "IdTipologia", "Nome", animaliRicoverati.Tipologia);
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", animaliRicoverati.IdUtente);
            return View(animaliRicoverati);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimaliRicoverati animaliRicoverati = db.AnimaliRicoverati.Find(id);
            TempData["NomeImmagine"] = animaliRicoverati.Foto;
            if (animaliRicoverati == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipologia = new SelectList(db.Tipologia, "IdTipologia", "Nome", animaliRicoverati.Tipologia);
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", animaliRicoverati.IdUtente);
            return View(animaliRicoverati);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnimaliRicoverati animaliRicoverati, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                //AnimaliRicoverati animali = db.AnimaliRicoverati.Find(animaliRicoverati.IdAnimali);
                if (foto != null && foto.ContentLength > 0)
                {
                    animaliRicoverati.Foto = foto.FileName;
                    string pathToSave = Server.MapPath("~/Content/ImgProgetto/") + foto.FileName;
                    foto.SaveAs(pathToSave);
                }
                else
                {
                    animaliRicoverati.Foto = TempData["NomeImmagine"].ToString();
                }
                if (animaliRicoverati.NumeroMicrochip == null)
                {
                    animaliRicoverati.NumeroMicrochip = "L'animale non possiede alcun microchip";
                }
                db.Entry(animaliRicoverati).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipologia = new SelectList(db.Tipologia, "IdTipologia", "Nome", animaliRicoverati.Tipologia);
            ViewBag.IdUtente = new SelectList(db.Utenti, "IdUtente", "Nome", animaliRicoverati.IdUtente);
            return View(animaliRicoverati);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimaliRicoverati animaliRicoverati = db.AnimaliRicoverati.Find(id);
            if (animaliRicoverati == null)
            {
                return HttpNotFound();
            }
            return View(animaliRicoverati);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimaliRicoverati animaliRicoverati = db.AnimaliRicoverati.Find(id);
            db.AnimaliRicoverati.Remove(animaliRicoverati);
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