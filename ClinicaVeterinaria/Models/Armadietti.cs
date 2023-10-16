namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Armadietti")]
    public partial class Armadietti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Armadietti()
        {
            Cassetti = new HashSet<Cassetti>();
        }

        [Key]
        public int IdArmadietto { get; set; }

        [Required]
        [StringLength(50)]
        public string CodiceArmadietto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cassetti> Cassetti { get; set; }
    }
}
