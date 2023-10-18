using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class CatalogoProdottiController : Controller
    {
        private ModelDBContext _context;

        public CatalogoProdottiController()
        {
            _context = new ModelDBContext();
        }

        // GET: CatalogoProdotti
        public ActionResult Index()
        {
            var prodotti = _context.Prodotti.Include("Ditte").ToList();
            return View(prodotti);
        }

    }
}