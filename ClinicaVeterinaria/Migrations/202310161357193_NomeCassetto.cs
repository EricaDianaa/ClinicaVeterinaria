namespace ClinicaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeCassetto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cassetti", "NomeCassetto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cassetti", "NomeCassetto");
        }
    }
}
