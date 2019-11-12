namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress1 = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email1 = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberType = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Numbers", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Adresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Numbers", new[] { "Contact_Id" });
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropIndex("dbo.Adresses", new[] { "Contact_Id" });
            DropTable("dbo.Numbers");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("dbo.Adresses");
        }
    }
}
