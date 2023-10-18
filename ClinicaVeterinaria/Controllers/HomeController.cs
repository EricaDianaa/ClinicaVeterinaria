using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{

    public class HomeController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

       // -------------RicercaAnimale----------
        public ActionResult RicercaAnimale()
        {
            Session["Animale"] = null;
            Session["Visite"] = null;
            return View();
        }
        [HttpPost]
        public JsonResult RicercaAnimale1(AnimaliRicoverati animale)
        {

            AnimaliRicoverati a = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == animale.NumeroMicrochip);
            Session["Animale"] = a;
            if (Session["Animale"] == null)
            {
                Session["NessunAnimale"] = "null";
            }

            List<AnimaliRicoverati> animal = new List<AnimaliRicoverati>();
            animal.Add(new AnimaliRicoverati { CognomeProprietario=a.CognomeProprietario,NomeProprietario=a.NomeProprietario,Nome=a.Nome,IdAnimali=a.IdAnimali,IdUtente=a.IdUtente,DataInizioRicovero=a.DataInizioRicovero,DataNascita=a.DataNascita,ColoreMantello=a.ColoreMantello});
            ViewBag.Nome = a.Tipologia1.Nome;
            return Json(animal);
        }

        public JsonResult RicercaAnimale2()
        {
          AnimaliRicoverati a = (AnimaliRicoverati) Session["Animale"];
             List<VisiteVeterinarie> v= new List<VisiteVeterinarie>();
            List<VisiteVeterinarie> visite = new List<VisiteVeterinarie>();
            if (a != null)
            {  
                AnimaliRicoverati an = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == a.NumeroMicrochip);
               int ID = an.IdAnimali;
               v = db.VisiteVeterinarie.Where(m => m.IdAnimale == ID).ToList();
           
            foreach(VisiteVeterinarie vis in v)
            {
              visite.Add(new VisiteVeterinarie { Descrizione= vis.Descrizione,idVisite=vis.idVisite,IdAnimale=vis.IdAnimale,Data=vis.Data});
            }
          
            }
           
           
            return Json(visite,JsonRequestBehavior.AllowGet);
        }
      
        //--------------------------------------

    }
}

