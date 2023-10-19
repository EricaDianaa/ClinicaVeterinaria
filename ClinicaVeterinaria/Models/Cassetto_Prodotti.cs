namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cassetto_Prodotti
    {
        [Key]
        public int IdCassettoProdotti { get; set; }
        [Display(Name = "Cassetto")]
        public int IdCassetto { get; set; }
        [Display(Name = "Prodotto")]
        public int IdProdotti { get; set; }

        public virtual Cassetti Cassetti { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
