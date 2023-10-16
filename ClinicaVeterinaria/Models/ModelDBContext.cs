using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ClinicaVeterinaria.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<AnimaliRicoverati> AnimaliRicoverati { get; set; }
        public virtual DbSet<Armadietti> Armadietti { get; set; }
        public virtual DbSet<Cassetti> Cassetti { get; set; }
        public virtual DbSet<Cassetto_Prodotti> Cassetto_Prodotti { get; set; }
        public virtual DbSet<Dettagli> Dettagli { get; set; }
        public virtual DbSet<Ditte> Ditte { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<ProdottiUsi> ProdottiUsi { get; set; }
        public virtual DbSet<Tipologia> Tipologia { get; set; }
        public virtual DbSet<UsiDisponibili> UsiDisponibili { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }
        public virtual DbSet<Vendite> Vendite { get; set; }
        public virtual DbSet<VisiteVeterinarie> VisiteVeterinarie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimaliRicoverati>()
                .HasMany(e => e.VisiteVeterinarie)
                .WithRequired(e => e.AnimaliRicoverati)
                .HasForeignKey(e => e.IdAnimale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Armadietti>()
                .HasMany(e => e.Cassetti)
                .WithRequired(e => e.Armadietti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cassetti>()
                .HasMany(e => e.Cassetto_Prodotti)
                .WithRequired(e => e.Cassetti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dettagli>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ditte>()
                .HasMany(e => e.Prodotti)
                .WithRequired(e => e.Ditte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Cassetto_Prodotti)
                .WithRequired(e => e.Prodotti)
                .HasForeignKey(e => e.IdProdotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Dettagli)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.ProdottiUsi)
                .WithRequired(e => e.Prodotti)
                .HasForeignKey(e => e.IdProdotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipologia>()
                .HasMany(e => e.AnimaliRicoverati)
                .WithRequired(e => e.Tipologia1)
                .HasForeignKey(e => e.Tipologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsiDisponibili>()
                .HasMany(e => e.ProdottiUsi)
                .WithRequired(e => e.UsiDisponibili)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Vendite)
                .WithRequired(e => e.Utenti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendite>()
                .HasMany(e => e.Dettagli)
                .WithRequired(e => e.Vendite)
                .WillCascadeOnDelete(false);
        }
    }
}
