using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class Carrello
    {
        public List<OggettoCarrello> carrello = new List<OggettoCarrello>();
    }

    public class OggettoCarrello
    {
        public int IdProduct { get; set; }
        public int qta { get; set; }
    }
}