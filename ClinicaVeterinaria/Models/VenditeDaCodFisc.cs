using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class VenditeDaCodFisc
    {
        public string DataAcquisto { get; set; }
        public string NumeroRicetta { get; set; }
        public List<Pr> ProdottiLista = new List<Pr>();
    }

    public class Pr
    {
        public string Nome { get; set; }
        public int Qta { get; set; }
        public decimal Prezzo { get; set; }
    }
}