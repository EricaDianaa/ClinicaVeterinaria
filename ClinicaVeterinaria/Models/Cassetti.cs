namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cassetti")]
    public partial class Cassetti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cassetti()
        {
            Cassetto_Prodotti = new HashSet<Cassetto_Prodotti>();
        }

        [Key]
        public int IdCassetto { get; set; }

        public int IdArmadietto { get; set; }

        public virtual Armadietti Armadietti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cassetto_Prodotti> Cassetto_Prodotti { get; set; }
    }
}
