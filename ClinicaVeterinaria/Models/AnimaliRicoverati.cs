namespace ClinicaVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnimaliRicoverati")]
    public partial class AnimaliRicoverati
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnimaliRicoverati()
        {
            VisiteVeterinarie = new HashSet<VisiteVeterinarie>();
        }

        [Key]
        public int IdAnimali { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Data Registrazione")]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int Tipologia { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Colore Mantello")]
        public string ColoreMantello { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data di nascita")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:d}")]
        public DateTime? DataNascita { get; set; }

        public bool? Microchip { get; set; }

        [StringLength(50)]
        [Display(Name = "Num. Microchip")]
        public string NumeroMicrochip { get; set; }

        [StringLength(50)]
        [Display(Name = "Nome proprietario")]
        public string NomeProprietario { get; set; }

        [StringLength(50)]
        [Display(Name = "Cognome proprietario")]
        public string CognomeProprietario { get; set; }
        [Display(Name = "Canile municipale")]
        public bool? IsComune { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data inizio ricovero")]
        public DateTime? DataInizioRicovero { get; set; }
        [Display(Name = "Cliente")]
        public int? IdUtente { get; set; }

        public virtual Utenti Utenti { get; set; }

        public virtual Tipologia Tipologia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisiteVeterinarie> VisiteVeterinarie { get; set; }
    }
}
