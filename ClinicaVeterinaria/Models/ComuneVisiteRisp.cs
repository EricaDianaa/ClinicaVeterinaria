using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class ComuneVisiteRisp
    {
        public string DescrizioneVisita { get; set; }
        public string DataInizio { get; set; }
        public string NomePaziente { get; set; }
        public string Tipologia { get; set; }
    }
}