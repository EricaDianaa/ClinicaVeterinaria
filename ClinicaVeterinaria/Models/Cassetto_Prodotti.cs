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

        public int IdCassetto { get; set; }

        public int IdProdotti { get; set; }

        public virtual Cassetti Cassetti { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
