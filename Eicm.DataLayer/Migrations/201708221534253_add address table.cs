namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaddresstable : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.VendorAccounts", newSchema: "Vendors");
            MoveTable(name: "dbo.ContractComments", newSchema: "Vendors");
            CreateTable(
                    "Vendors.AccountContracts",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Vendors.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("Vendors.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.ContractId);
            CreateTable(
                "Core.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Core.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Vendors.ContactAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Vendors.VendorAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AddressType = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("Vendors.Contacts", "ContactType");
        }
        
        public override void Down()
        {
            AddColumn("Vendors.Contacts", "ContactType", c => c.Int(nullable: false));
            DropTable("Vendors.VendorAddresses");
            DropTable("Vendors.ContactAddresses");
            DropTable("Core.AddressTypes");
            DropTable("Core.Addresses");
            MoveTable(name: "Vendors.ContractComments", newSchema: "dbo");
            MoveTable(name: "Vendors.AccountContracts", newSchema: "dbo");
        }
    }
}
