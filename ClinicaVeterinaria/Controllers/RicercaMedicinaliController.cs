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
        ModelDBContext db = new ModelDBContext();
        // GET: RicercaMedicinali
        public ActionResult RicercaMedicinale()
        {
            return View();
        }
       // [HttpPost]
        public JsonResult RicercaMedicinaleData(DateTime data)
        {
           int Totale = db.Vendite.Count(m => m.DataVendita == data);

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
                v.Add(ve);
            }
            return Json(v);
        }

    }
}