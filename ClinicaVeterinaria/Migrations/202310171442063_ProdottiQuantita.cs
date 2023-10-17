namespace ClinicaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdottiQuantita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prodotti", "Quantita", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prodotti", "Quantita");
        }
    }
}
