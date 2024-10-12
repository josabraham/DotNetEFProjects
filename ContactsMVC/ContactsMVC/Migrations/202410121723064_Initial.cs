namespace ContactsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactGroups",
                c => new
                    {
                        ContactGroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.ContactGroupId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        ContactGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactGroups", t => t.ContactGroupId, cascadeDelete: true)
                .Index(t => t.ContactGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ContactGroupId", "dbo.ContactGroups");
            DropIndex("dbo.Contacts", new[] { "ContactGroupId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactGroups");
        }
    }
}
