namespace ClinicaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimaliRicoverati",
                c => new
                    {
                        IdAnimali = c.Int(nullable: false, identity: true),
                        DataRegistrazione = c.DateTime(nullable: false, storeType: "date"),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Tipologia = c.Int(nullable: false),
                        ColoreMantello = c.String(nullable: false, maxLength: 50),
                        DataNascita = c.DateTime(storeType: "date"),
                        Microchip = c.Boolean(),
                        NumeroMicrochip = c.String(maxLength: 50),
                        NomeProprietario = c.String(maxLength: 50),
                        CognomeProprietario = c.String(maxLength: 50),
                        IsComune = c.Boolean(),
                        Foto = c.String(maxLength: 50),
                        DataInizioRicovero = c.DateTime(storeType: "date"),
                        IdUtente = c.Int(),
                    })
                .PrimaryKey(t => t.IdAnimali)
                .ForeignKey("dbo.Tipologia", t => t.Tipologia)
                .ForeignKey("dbo.Utenti", t => t.IdUtente)
                .Index(t => t.Tipologia)
                .Index(t => t.IdUtente);
            
            CreateTable(
                "dbo.Tipologia",
                c => new
                    {
                        IdTipologia = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdTipologia);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Ruolo = c.String(maxLength: 50),
                        CodiceFiscale = c.String(nullable: false, maxLength: 16),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUtente);
            
            CreateTable(
                "dbo.Vendite",
                c => new
                    {
                        IdVendita = c.Int(nullable: false, identity: true),
                        IdUtente = c.Int(nullable: false),
                        DataVendita = c.DateTime(nullable: false, storeType: "date"),
                        NumeroRicetta = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdVendita)
                .ForeignKey("dbo.Utenti", t => t.IdUtente)
                .Index(t => t.IdUtente);
            
            CreateTable(
                "dbo.Dettagli",
                c => new
                    {
                        IdDettaglio = c.Int(nullable: false, identity: true),
                        IdProdotto = c.Int(nullable: false),
                        Quantita = c.Int(nullable: false),
                        IdVendita = c.Int(nullable: false),
                        Prezzo = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.IdDettaglio)
                .ForeignKey("dbo.Prodotti", t => t.IdProdotto)
                .ForeignKey("dbo.Vendite", t => t.IdVendita)
                .Index(t => t.IdProdotto)
                .Index(t => t.IdVendita);
            
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        IdProdotto = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Descrizione = c.String(nullable: false, maxLength: 50),
                        IdDitta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProdotto)
                .ForeignKey("dbo.Ditte", t => t.IdDitta)
                .Index(t => t.IdDitta);
            
            CreateTable(
                "dbo.Cassetto_Prodotti",
                c => new
                    {
                        IdCassettoProdotti = c.Int(nullable: false, identity: true),
                        IdCassetto = c.Int(nullable: false),
                        IdProdotti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCassettoProdotti)
                .ForeignKey("dbo.Cassetti", t => t.IdCassetto)
                .ForeignKey("dbo.Prodotti", t => t.IdProdotti)
                .Index(t => t.IdCassetto)
                .Index(t => t.IdProdotti);
            
            CreateTable(
                "dbo.Cassetti",
                c => new
                    {
                        IdCassetto = c.Int(nullable: false, identity: true),
                        IdArmadietto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCassetto)
                .ForeignKey("dbo.Armadietti", t => t.IdArmadietto)
                .Index(t => t.IdArmadietto);
            
            CreateTable(
                "dbo.Armadietti",
                c => new
                    {
                        IdArmadietto = c.Int(nullable: false, identity: true),
                        CodiceArmadietto = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdArmadietto);
            
            CreateTable(
                "dbo.Ditte",
                c => new
                    {
                        IdDitta = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Recapito = c.String(nullable: false, maxLength: 50),
                        Indirizzo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdDitta);
            
            CreateTable(
                "dbo.ProdottiUsi",
                c => new
                    {
                        IdProdottiUsi = c.Int(nullable: false, identity: true),
                        IdUsi = c.Int(nullable: false),
                        IdProdotti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProdottiUsi)
                .ForeignKey("dbo.UsiDisponibili", t => t.IdUsi)
                .ForeignKey("dbo.Prodotti", t => t.IdProdotti)
                .Index(t => t.IdUsi)
                .Index(t => t.IdProdotti);
            
            CreateTable(
                "dbo.UsiDisponibili",
                c => new
                    {
                        IdUsi = c.Int(nullable: false, identity: true),
                        Descrizione = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUsi);
            
            CreateTable(
                "dbo.VisiteVeterinarie",
                c => new
                    {
                        idVisite = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        IdAnimale = c.Int(nullable: false),
                        ObiettivoEsame = c.String(nullable: false, maxLength: 100),
                        Descrizione = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idVisite)
                .ForeignKey("dbo.AnimaliRicoverati", t => t.IdAnimale)
                .Index(t => t.IdAnimale);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisiteVeterinarie", "IdAnimale", "dbo.AnimaliRicoverati");
            DropForeignKey("dbo.Vendite", "IdUtente", "dbo.Utenti");
            DropForeignKey("dbo.Dettagli", "IdVendita", "dbo.Vendite");
            DropForeignKey("dbo.ProdottiUsi", "IdProdotti", "dbo.Prodotti");
            DropForeignKey("dbo.ProdottiUsi", "IdUsi", "dbo.UsiDisponibili");
            DropForeignKey("dbo.Prodotti", "IdDitta", "dbo.Ditte");
            DropForeignKey("dbo.Dettagli", "IdProdotto", "dbo.Prodotti");
            DropForeignKey("dbo.Cassetto_Prodotti", "IdProdotti", "dbo.Prodotti");
            DropForeignKey("dbo.Cassetto_Prodotti", "IdCassetto", "dbo.Cassetti");
            DropForeignKey("dbo.Cassetti", "IdArmadietto", "dbo.Armadietti");
            DropForeignKey("dbo.AnimaliRicoverati", "IdUtente", "dbo.Utenti");
            DropForeignKey("dbo.AnimaliRicoverati", "Tipologia", "dbo.Tipologia");
            DropIndex("dbo.VisiteVeterinarie", new[] { "IdAnimale" });
            DropIndex("dbo.ProdottiUsi", new[] { "IdProdotti" });
            DropIndex("dbo.ProdottiUsi", new[] { "IdUsi" });
            DropIndex("dbo.Cassetti", new[] { "IdArmadietto" });
            DropIndex("dbo.Cassetto_Prodotti", new[] { "IdProdotti" });
            DropIndex("dbo.Cassetto_Prodotti", new[] { "IdCassetto" });
            DropIndex("dbo.Prodotti", new[] { "IdDitta" });
            DropIndex("dbo.Dettagli", new[] { "IdVendita" });
            DropIndex("dbo.Dettagli", new[] { "IdProdotto" });
            DropIndex("dbo.Vendite", new[] { "IdUtente" });
            DropIndex("dbo.AnimaliRicoverati", new[] { "IdUtente" });
            DropIndex("dbo.AnimaliRicoverati", new[] { "Tipologia" });
            DropTable("dbo.VisiteVeterinarie");
            DropTable("dbo.UsiDisponibili");
            DropTable("dbo.ProdottiUsi");
            DropTable("dbo.Ditte");
            DropTable("dbo.Armadietti");
            DropTable("dbo.Cassetti");
            DropTable("dbo.Cassetto_Prodotti");
            DropTable("dbo.Prodotti");
            DropTable("dbo.Dettagli");
            DropTable("dbo.Vendite");
            DropTable("dbo.Utenti");
            DropTable("dbo.Tipologia");
            DropTable("dbo.AnimaliRicoverati");
        }
    }
}
