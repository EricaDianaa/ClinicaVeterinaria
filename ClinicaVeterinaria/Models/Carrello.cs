using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class Carrello
    {
        public List<Carrello> carrello = new List<Carrello>();

        public int IdProduct { get; set; }
        public int qta { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
    }
}