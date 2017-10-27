namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalfieldsaddedcontracttable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "TypeCodes.Vendors", newName: "AssetCategory");
            CreateTable(
                "Vendors.VendorContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Vendors.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            AddColumn("Assets.Assets", "UserRangeId", c => c.Int());
            AddColumn("Assets.Assets", "AssetCategoryId", c => c.Int());
            AddColumn("Assets.Assets", "DollarThresholdId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.VendorContacts", "ContactId", "Vendors.Contacts");
            DropIndex("Vendors.VendorContacts", new[] { "ContactId" });
            DropColumn("Assets.Assets", "DollarThresholdId");
            DropColumn("Assets.Assets", "AssetCategoryId");
            DropColumn("Assets.Assets", "UserRangeId");
            DropTable("Vendors.VendorContacts");
            RenameTable(name: "TypeCodes.AssetCategory", newName: "Vendors");
        }
    }
}
