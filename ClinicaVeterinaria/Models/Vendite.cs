namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendite")]
    public partial class Vendite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendite()
        {
            Dettagli = new HashSet<Dettagli>();
        }

        [Key]
        public int IdVendita { get; set; }

        public int IdUtente { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataVendita { get; set; }

        [StringLength(50)]
        public string NumeroRicetta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettagli> Dettagli { get; set; }

        public virtual Utenti Utenti { get; set; }
    }
}
