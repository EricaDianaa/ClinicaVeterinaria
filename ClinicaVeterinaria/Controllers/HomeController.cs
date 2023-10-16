using ClinicaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    
    public class HomeController : Controller
    {
        ModelDBContext db=new ModelDBContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        //-------------RicercaAnimale-----------
        public ActionResult RicercaAnimale()
        {
            Session["Animale"] = null;
            Session["Visite"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult RicercaAnimale(AnimaliRicoverati animale)
        {
            Session["Animale"] = null;
            Session["Visite"] = null;
            Session["NessunAnimale"] = null;
            AnimaliRicoverati a = db.AnimaliRicoverati.FirstOrDefault(m => m.NumeroMicrochip == animale.NumeroMicrochip);
            Session["Animale"]=a;
            if (Session["Animale"] == null)
            {
                Session["NessunAnimale"] = "null";
            }
            if(Session["Animale"] != null)
            {
            int ID = a.IdAnimali;
            List<VisiteVeterinarie> v = db.VisiteVeterinarie.Where(m => m.IdAnimale == ID).ToList();
            Session["Visite"] = v;
            }
           
            return View(a);
        }
        public ActionResult AnimaleRicercato()
        {
            AnimaliRicoverati a = (AnimaliRicoverati)Session["Animale"];
            if (a.Foto == null)
            {
                Session["Foto"] = null;
            }
            else
            {
                Session["Foto"] = "not null";
            }
            ViewBag.Nome =a.Tipologia1.Nome;
            return PartialView(a);
        }
        public ActionResult VisitaAnimale()
        {
            List<VisiteVeterinarie> Visite =(List<VisiteVeterinarie>) Session["Visite"]; 
            return PartialView(Visite);
        }
        //--------------------------------------

    }
}
