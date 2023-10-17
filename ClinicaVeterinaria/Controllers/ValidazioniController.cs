using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class ValidazioniController : Controller
    {
        //gestisce la validazioni lato client per i text input
        private static ModelDBContext db = new ModelDBContext();

        public ActionResult IsEmailValid(string email)
        {
            bool isValid = db.Utenti.All(x => x.Email != email); ;

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsProductNameValid(string Nome)
        {
            bool isValid = db.Prodotti.All(x => x.Nome != Nome); ;
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }
    }
}