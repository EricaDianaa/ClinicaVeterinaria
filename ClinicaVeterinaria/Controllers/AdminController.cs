using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminView()
        {
            return View();
        }

        public ActionResult AdminMenu()
        {
            return View();
        }

        public ActionResult Cassa()
        {
            return View();
        }
    }
}