using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class ComuneController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Comune
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ComuneVisite()
        {
            List<AnimaliRicoverati> visite = db.AnimaliRicoverati.Where(v => v.IsComune == true).ToList();
            List<ComuneVisiteRisp> recuperoVisite = new List<ComuneVisiteRisp>();
            foreach(AnimaliRicoverati a in  visite)
            {
            List<VisiteVeterinarie>visiteVeterinaries = db.VisiteVeterinarie.Where(v => v.IdAnimale == a.IdAnimali).ToList();
                foreach(VisiteVeterinarie v in visiteVeterinaries)
                {
                    recuperoVisite.Add(new ComuneVisiteRisp { DescrizioneVisita = v.Descrizione, DataInizio = v.Data.ToShortDateString(), NomePaziente = a.Nome, Tipologia = a.Tipologia1.Nome });
                }
            }
            return Json(recuperoVisite);
        }
    }
}