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
        public DateTime DataRegistrazione { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int Tipologia { get; set; }

        [Required]
        [StringLength(50)]
        public string ColoreMantello { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString ="{0:d}")]
        public DateTime? DataNascita { get; set; }

        public bool? Microchip { get; set; }

        [StringLength(50)]
        [Display(Name="Numero Microchip")]
        public string NumeroMicrochip { get; set; }

        [StringLength(50)]
        public string NomeProprietario { get; set; }

        [StringLength(50)]
        public string CognomeProprietario { get; set; }

        public bool? IsComune { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataInizioRicovero { get; set; }

        public int? IdUtente { get; set; }

        public virtual Utenti Utenti { get; set; }

        public virtual Tipologia Tipologia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisiteVeterinarie> VisiteVeterinarie { get; set; }
    }
}
