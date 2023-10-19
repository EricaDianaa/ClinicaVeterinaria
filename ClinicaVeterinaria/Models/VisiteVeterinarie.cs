namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisiteVeterinarie")]
    public partial class VisiteVeterinarie
    {
        [Key]
        public int idVisite { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }
        [NotMapped]
        public string DataString { get; set; }

        public int IdAnimale { get; set; }

        [Required]
        [StringLength(100)]
        public string ObiettivoEsame { get; set; }

        [Required]
        public string Descrizione { get; set; }

        public virtual AnimaliRicoverati AnimaliRicoverati { get; set; }
    }
}
