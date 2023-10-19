namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dettagli")]
    public partial class Dettagli
    {
        [Key]
        public int IdDettaglio { get; set; }
        [Display(Name = "Prodotto")]
        public int IdProdotto { get; set; }
        [Display(Name = "Quantità")]
        public int Quantita { get; set; }
        [Display(Name = "Vendita")]
        public int IdVendita { get; set; }

        [Column(TypeName = "money")]
        public decimal Prezzo { get; set; }

        public virtual Prodotti Prodotti { get; set; }

        public virtual Vendite Vendite { get; set; }
    }
}
