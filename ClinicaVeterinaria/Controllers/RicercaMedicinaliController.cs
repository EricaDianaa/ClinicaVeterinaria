using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class RicercaMedicinaliController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: RicercaMedicinali
        public ActionResult RicercaMedicinale()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RicercaMedicinaleData(DateTime DataVendita)
        {
            List<Vendite> Totale1 = db.Vendite.Where(m => m.DataVendita == DataVendita).ToList();
            List<ElencoMedicinaliVenduti> Totale = new List<ElencoMedicinaliVenduti>();
            foreach (Vendite v in Totale1)
            {
                Totale.Add(new ElencoMedicinaliVenduti { Nome = v.Utenti.Nome, Ricetta = v.NumeroRicetta });
            }
            return Json(Totale);
        }

        [HttpPost]
        public JsonResult RicercaMedicinaleCF(string CodiceFiscale)
        {
            
            Utenti user = db.Utenti.FirstOrDefault(m => m.CodiceFiscale == CodiceFiscale);
            List<Vendite> vendita= db.Vendite.Where(m => m.IdUtente == user.IdUtente).ToList();
            List<Vendite> v = new List<Vendite>();
            foreach (Vendite ve in vendita)
            {
                v.Add(new Vendite { IdVendita = ve.IdVendita, IdUtente = ve.IdUtente, DateVenditaString = ve.DataVendita.ToShortDateString().ToString(), NumeroRicetta = ve.NumeroRicetta });
            }
            return Json(v);
        }
    }
}