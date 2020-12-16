namespace Phephi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonModels",
                c => new
                    {
                        PersonIdentification = c.Int(name: "Person Identification", nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        contact = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Pizza = c.Boolean(nullable: false),
                        Pasta = c.Boolean(nullable: false),
                        PapandWors = c.Boolean(name: "Pap and Wors", nullable: false),
                        ChickenStirFry = c.Boolean(name: "Chicken Stir Fry", nullable: false),
                        BeefStirFry = c.Boolean(name: "Beef Stir Fry", nullable: false),
                        Other = c.Boolean(nullable: false),
                        Iliketoeatout = c.String(name: "I like to eat out", nullable: false),
                        Iliketowatchmovies = c.String(name: "I like to watch movies", nullable: false),
                        IliketowatchTV = c.String(name: "I like to watch TV", nullable: false),
                        Iliketolistentotheradio = c.String(name: "I like to listen to the radio", nullable: false),
                    })
                .PrimaryKey(t => t.PersonIdentification);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonModels");
        }
    }
}
