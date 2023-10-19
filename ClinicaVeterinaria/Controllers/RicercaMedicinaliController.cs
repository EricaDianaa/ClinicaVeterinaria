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
            ViewBag.IdProdotti = new SelectList(db.Prodotti, "IdProdotto", "Nome");
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
            List<Vendite> vendita = db.Vendite.Where(m => m.IdUtente == user.IdUtente).ToList();
            List<VenditeDaCodFisc> v = new List<VenditeDaCodFisc>();
            List<Pr> prodottiList = new List<Pr>();
            foreach (Vendite ve in vendita)
            {
                foreach (Dettagli dettagli in ve.Dettagli)
                {
                    prodottiList.Add(new Pr { Nome = dettagli.Prodotti.Nome, Qta = dettagli.Quantita, Prezzo = dettagli.Prezzo });
                }
                //v.Add(new Vendite { IdVendita = ve.IdVendita, IdUtente = ve.IdUtente, DateVenditaString = ve.DataVendita.ToShortDateString().ToString(), NumeroRicetta = ve.NumeroRicetta });
                v.Add(new VenditeDaCodFisc
                {
                    DataAcquisto = ve.DataVendita.ToShortDateString().ToString(),
                    NumeroRicetta = ve.NumeroRicetta,
                    ProdottiLista = prodottiList
                });
            }
            return Json(v);
        }

        [HttpPost]
        public JsonResult RicercaMedicinaleCasetto(int IdProdotti)
        {
            
            Cassetto_Prodotti cassetto= db.Cassetto_Prodotti.Where(M=>M.IdProdotti == IdProdotti).FirstOrDefault();
            Cassetto_Prodotti cassetto1 = new Cassetto_Prodotti();
            if (cassetto != null) {
             Cassetti IdArmadietti = db.Cassetti.Where(M => M.IdCassetto ==cassetto.IdCassetto).FirstOrDefault();
            Armadietti armadietto=db.Armadietti.Where(m=>m.IdArmadietto==IdArmadietti.IdArmadietto).FirstOrDefault();
            Prodotti p =db.Prodotti.Where(M => M.IdProdotto == IdProdotti).FirstOrDefault();
             cassetto1 = new Cassetto_Prodotti { IdProdotti = cassetto.IdProdotti, IdCassetto= cassetto.IdCassetto, NomeCassetto = cassetto.Cassetti.NomeCassetto,Armadietto=armadietto.CodiceArmadietto,NomeMedicinale=p.Nome };
            }
            
            return Json(cassetto1);
        }
    }
}