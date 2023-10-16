using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    public class RegisterController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Ruolo")]Utenti user)
        {
            user.Ruolo = "User";
            if(ModelState.IsValid)
            {
                db.Utenti.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}