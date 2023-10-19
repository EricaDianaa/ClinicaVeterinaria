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
        private ModelDBContext db = new ModelDBContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // -------------RicercaAnimale----------
        public ActionResult RicercaAnimale()
        {
            Session["Animale"] = null;
            Session["NessunAnimale"] = null;
            return View();
        }

        [HttpPost]
        public JsonResult RicercaAnimale1(AnimaliRicoverati animale)
        {
            AnimaliRicoverati a = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == animale.NumeroMicrochip);
            Session["Animale"] = a;

            List<AnimaliRicoverati> animal = new List<AnimaliRicoverati>();
            if (a != null)
            {
                animal.Add(new AnimaliRicoverati { Foto = a.Foto, CognomeProprietario = a.CognomeProprietario, NomeProprietario = a.NomeProprietario, Nome = a.Nome, IdAnimali = a.IdAnimali, IdUtente = a.IdUtente, DataInizioRicovero = a.DataInizioRicovero, DataInizioRicoveroString = a.DataInizioRicovero?.ToShortDateString().ToString(), DataNascita = a.DataNascita, DataNascitaString = a.DataNascita?.ToShortDateString().ToString(), DataregistrazioneString = a.DataRegistrazione.ToShortDateString().ToString(), ColoreMantello = a.ColoreMantello, TipologiaNome = a.Tipologia1.Nome });
                ViewBag.Nome = a.Tipologia1.Nome;
            }
            else
            {
                Session["NessunAnimale"] = "null";
            }

            return Json(animal);
        }

        //ricerca le visite collegate all'animale
        public JsonResult RicercaAnimale2()
        {
            AnimaliRicoverati a = (AnimaliRicoverati)Session["Animale"];
            List<VisiteVeterinarie> v = new List<VisiteVeterinarie>();
            List<VisiteVeterinarie> visite = new List<VisiteVeterinarie>();
            if (a != null)
            {
                AnimaliRicoverati an = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == a.NumeroMicrochip);
                int ID = an.IdAnimali;
                v = db.VisiteVeterinarie.Where(m => m.IdAnimale == ID).ToList();

                foreach (VisiteVeterinarie vis in v)
                {
                    visite.Add(new VisiteVeterinarie { Descrizione = vis.Descrizione, idVisite = vis.idVisite, IdAnimale = vis.IdAnimale, Data = vis.Data, DataString = vis.Data.ToShortDateString().ToString() });
                }
            }

            return Json(visite, JsonRequestBehavior.AllowGet);
        }

        //--------------------------------------
        //------------------RICECA DA ANONIMI--------------------

        public ActionResult RicercaAnonimaDaChip()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RicercaAnonimaDaChip(AnimaliRicoverati animale)
        {
            AnimaliRicoverati a = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == animale.NumeroMicrochip);

            List<AnimaliRicoverati> animal = new List<AnimaliRicoverati>();
            if (a != null)
            {
                animal.Add(new AnimaliRicoverati { Foto = a.Foto, CognomeProprietario = a.CognomeProprietario, NomeProprietario = a.NomeProprietario, Nome = a.Nome, IdAnimali = a.IdAnimali, IdUtente = a.IdUtente, DataInizioRicovero = a.DataInizioRicovero, DataInizioRicoveroString = a.DataInizioRicovero?.ToShortDateString().ToString(), DataNascita = a.DataNascita, DataNascitaString = a.DataNascita?.ToShortDateString().ToString(), DataregistrazioneString = a.DataRegistrazione.ToShortDateString().ToString(), ColoreMantello = a.ColoreMantello, TipologiaNome = a.Tipologia1.Nome });
                ViewBag.Nome = a.Tipologia1.Nome;
            }
            return Json(animal);
        }
    }
}