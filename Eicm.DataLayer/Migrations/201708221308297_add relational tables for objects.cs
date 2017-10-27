namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationaltablesforobjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Vendors.Contracts", "AccountId", "Vendors.Accounts");
            DropForeignKey("Vendors.Accounts", "VendorId", "Vendors.Vendors");
            DropIndex("Vendors.Accounts", new[] { "VendorId" });
            DropIndex("Vendors.Contracts", new[] { "AccountId" });
            CreateTable(
                "dbo.AccountContracts",
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
                "dbo.VendorAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Vendors.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("Vendors.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.AccountId);
            
            AddColumn("Assets.Assets", "ManufacturerId", c => c.Int());
            AddColumn("Assets.Assets", "ModelId", c => c.Int());
            AddColumn("Assets.Assets", "SerialNumber", c => c.String());
            AddColumn("Assets.Assets", "OfficeId", c => c.Int());
            DropColumn("Vendors.Accounts", "VendorId");
            DropColumn("Vendors.Contracts", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("Vendors.Contracts", "AccountId", c => c.Int(nullable: false));
            AddColumn("Vendors.Accounts", "VendorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VendorAccounts", "VendorId", "Vendors.Vendors");
            DropForeignKey("dbo.VendorAccounts", "AccountId", "Vendors.Accounts");
            DropForeignKey("dbo.AccountContracts", "AccountId", "Vendors.Accounts");
            DropForeignKey("dbo.AccountContracts", "ContractId", "Vendors.Contracts");
            DropIndex("dbo.VendorAccounts", new[] { "AccountId" });
            DropIndex("dbo.VendorAccounts", new[] { "VendorId" });
            DropIndex("dbo.AccountContracts", new[] { "ContractId" });
            DropIndex("dbo.AccountContracts", new[] { "AccountId" });
            DropColumn("Assets.Assets", "OfficeId");
            DropColumn("Assets.Assets", "SerialNumber");
            DropColumn("Assets.Assets", "ModelId");
            DropColumn("Assets.Assets", "ManufacturerId");
            DropTable("dbo.VendorAccounts");
            DropTable("dbo.AccountContracts");
            CreateIndex("Vendors.Contracts", "AccountId");
            CreateIndex("Vendors.Accounts", "VendorId");
            AddForeignKey("Vendors.Accounts", "VendorId", "Vendors.Vendors", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.Contracts", "AccountId", "Vendors.Accounts", "Id", cascadeDelete: true);
        }
    }
}
