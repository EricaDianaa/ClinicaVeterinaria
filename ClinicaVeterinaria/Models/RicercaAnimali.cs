using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class RicercaAnimali
    {

        public int IdAnimali { get; set; }


        public DateTime DataRegistrazione { get; set; }


        public string Nome { get; set; }

        public int Tipologia { get; set; }


        public string ColoreMantello { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DataNascita { get; set; }

        public bool? Microchip { get; set; }

        public string NumeroMicrochip { get; set; }

        public string NomeProprietario { get; set; }


        public string CognomeProprietario { get; set; }

        public bool? IsComune { get; set; }


        public string Foto { get; set; }


        public DateTime? DataInizioRicovero { get; set; }

        public int? IdUtente { get; set; }

        public int IdVendita { get; set; }


        public DateTime DataVendita { get; set; }


        public string NumeroRicetta { get; set; }
        public int IdTipologia { get; set; }

        public string NomeTipologia { get; set; }
    }
}