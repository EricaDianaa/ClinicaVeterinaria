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
    }
}