namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        Clientfk = c.Int(nullable: false),
                        Productfk = c.Int(nullable: false),
                        DateAchat = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        TyAbo_IdAbo = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Clientfk, t.Productfk })
                .ForeignKey("dbo.TyAboes", t => t.TyAbo_IdAbo)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.TyAbo_IdAbo)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        TyAbo_IdAbo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TyAboes", t => t.TyAbo_IdAbo)
                .Index(t => t.TyAbo_IdAbo);
            
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        AnnonceId = c.Int(nullable: false, identity: true),
                        TypeAn = c.Int(nullable: false),
                        Description = c.String(),
                        address = c.String(),
                        surface = c.Single(nullable: false),
                        chambres = c.Int(nullable: false),
                        clientId = c.Int(nullable: false),
                        images = c.String(),
                    })
                .PrimaryKey(t => t.AnnonceId)
                .ForeignKey("dbo.Clients", t => t.clientId)
                .Index(t => t.clientId);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        visiteurID = c.Int(nullable: false),
                        annonceID = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Annonces", t => t.annonceID)
                .ForeignKey("dbo.Clients", t => t.visiteurID)
                .Index(t => t.visiteurID)
                .Index(t => t.annonceID);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                        Livraison = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                        Disponibilite = c.Int(nullable: false),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Client_Id = c.Int(),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.TyAboes",
                c => new
                    {
                        IdAbo = c.Int(nullable: false, identity: true),
                        Prix = c.Single(nullable: false),
                        Libelle = c.String(),
                        TypeAbo = c.String(),
                        Description = c.String(),
                        Dure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAbo);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Abonnements", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.Abonnements", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.CustomUserRoles", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Meubles", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.CustomUserLogins", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.CustomUserClaims", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.RDVs", "visiteurID", "dbo.Clients");
            DropForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces");
            DropForeignKey("dbo.Annonces", "clientId", "dbo.Clients");
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "Client_Id" });
            DropIndex("dbo.Meubles", new[] { "Client_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Client_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Client_Id" });
            DropIndex("dbo.RDVs", new[] { "annonceID" });
            DropIndex("dbo.RDVs", new[] { "visiteurID" });
            DropIndex("dbo.Annonces", new[] { "clientId" });
            DropIndex("dbo.Clients", new[] { "TyAbo_IdAbo" });
            DropIndex("dbo.Abonnements", new[] { "Client_Id" });
            DropIndex("dbo.Abonnements", new[] { "TyAbo_IdAbo" });
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.TyAboes");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Meubles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.RDVs");
            DropTable("dbo.Annonces");
            DropTable("dbo.Clients");
            DropTable("dbo.Abonnements");
        }
    }
}
