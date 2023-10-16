using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ClinicaVeterinaria.Controllers
{
    public class LoginController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User utente)
        {
            if (ModelState.IsValid)
            {
                Utenti u = db.Utenti.Where(ut => ut.Email == utente.Email && ut.Password == utente.Password).FirstOrDefault();
                if(u != null)
                {
                    FormsAuthentication.SetAuthCookie(u.Email, false);
                    return RedirectToAction("Index", "AnimaliRicoverati");
                }
                else
                {
                    ModelState.AddModelError("", "Credenziali non valide. Controlla che le tue credenziali siano state inserite correttamente.");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}