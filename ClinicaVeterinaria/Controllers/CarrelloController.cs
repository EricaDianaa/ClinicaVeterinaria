using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class CarrelloController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        private List<SelectListItem> prodotti
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Prodotti> listPr = db.Prodotti.ToList();
                foreach (Prodotti prodotto in listPr)
                {
                    list.Add(new SelectListItem { Text = prodotto.Descrizione, Value = prodotto.IdProdotto.ToString() });
                }
                return list;
            }
        }

        // GET: Carrello
        public ActionResult CreaCarrello()
        {
            if (Session["cart"] == null)
            {
                List<Carrello> carrello = new List<Carrello>();
                Session["cart"] = carrello;
            }

            ViewBag.prodotti = prodotti;
            //return View();
            return PartialView("CreaCarrello");
        }

        [HttpPost]
        public ActionResult CreaCarrello(Carrello oc)
        {
            if (ModelState.IsValid)
            {
                if (Session["cart"] == null)
                {
                    List<Carrello> carrello = new List<Carrello>();
                    Session["cart"] = carrello;
                }

                List<Carrello> cart = (List<Carrello>)Session["cart"];
                Prodotti prodotto = db.Prodotti.Where(x => x.IdProdotto == oc.IdProduct).FirstOrDefault();
                Carrello item = new Carrello
                {
                    IdProduct = prodotto.IdProdotto,
                    qta = oc.qta,
                    Nome = prodotto.Nome,
                    Prezzo = prodotto.Prezzo
                };

                cart.Add(item);
                Session["cart"] = cart;
            }
            ViewBag.prodotti = prodotti;
            return RedirectToAction("Cassa","Admin");
        }

        public ActionResult MostraCarrello()
        {
            List<Carrello> cart = (List<Carrello>)Session["cart"];
            return PartialView("_MostraCarrello", cart);
        }

        public ActionResult Elimina(int id)
        {
            List<Carrello> cart = (List<Carrello>)Session["cart"];
            cart.RemoveAt(id - 1);
            Session["cart"] = cart;
            return RedirectToAction("Cassa", "Admin");
        }
    }
}