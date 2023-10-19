namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            Cassetto_Prodotti = new HashSet<Cassetto_Prodotti>();
            Dettagli = new HashSet<Dettagli>();
            ProdottiUsi = new HashSet<ProdottiUsi>();
        }

        [Key]
        public int IdProdotto { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [Remote("IsProductNameValid", "Validazioni", ErrorMessage = "Nome gia presente")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public string Descrizione { get; set; }

        public int Quantita { get; set; }

        public int IdDitta { get; set; }

        public decimal Prezzo { get; set; }

        [NotMapped]
        public int CassettoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cassetto_Prodotti> Cassetto_Prodotti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettagli> Dettagli { get; set; }

        public virtual Ditte Ditte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdottiUsi> ProdottiUsi { get; set; }
    }
}