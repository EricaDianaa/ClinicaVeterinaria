namespace ClinicaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visita_vet_prodotti_dettagli : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prodotti", "Descrizione", c => c.String(nullable: false));
            AlterColumn("dbo.UsiDisponibili", "Descrizione", c => c.String(nullable: false));
            AlterColumn("dbo.VisiteVeterinarie", "Descrizione", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisiteVeterinarie", "Descrizione", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UsiDisponibili", "Descrizione", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Prodotti", "Descrizione", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
