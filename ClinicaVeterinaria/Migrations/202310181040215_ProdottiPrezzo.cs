namespace ClinicaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdottiPrezzo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prodotti", "Prezzo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prodotti", "Prezzo");
        }
    }
}
