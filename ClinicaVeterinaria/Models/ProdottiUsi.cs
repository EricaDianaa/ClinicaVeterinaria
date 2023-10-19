namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdottiUsi")]
    public partial class ProdottiUsi
    {
        [Key]
        public int IdProdottiUsi { get; set; }
        [Display(Name = "Uso prodotto")]
        public int IdUsi { get; set; }
        [Display(Name = "Prodotto")]
        public int IdProdotti { get; set; }

        public virtual Prodotti Prodotti { get; set; }

        public virtual UsiDisponibili UsiDisponibili { get; set; }
    }
}
