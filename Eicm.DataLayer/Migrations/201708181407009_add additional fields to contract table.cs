namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadditionalfieldstocontracttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Vendors.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "TypeCodes.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.PricingMethods",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Vendors.Contracts", "LineOfBusiness", c => c.Int(nullable: false));
            AddColumn("Vendors.Contracts", "PricingMethod", c => c.Int(nullable: false));
            AddColumn("Vendors.Contracts", "PricingAmount", c => c.Int());
            AddColumn("Vendors.Contracts", "PriceBreaks", c => c.String());
            AddColumn("Vendors.Contracts", "YearlyBudget", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Vendors.Contracts", "MonthlyBudget", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Vendors.Contracts", "GeneralLedgerAccount", c => c.Int(nullable: false));
            AddColumn("Vendors.Contracts", "Location", c => c.Int());
            AddColumn("Assets.Assets", "CapabilityId", c => c.Int());
            AddColumn("Assets.Assets", "LicenseCount", c => c.Int());
            DropColumn("Assets.Assets", "Capability");
        }
        
        public override void Down()
        {
            AddColumn("Assets.Assets", "Capability", c => c.String());
            DropForeignKey("dbo.ContractComments", "ContractId", "Vendors.Contracts");
            DropIndex("dbo.ContractComments", new[] { "ContractId" });
            DropColumn("Assets.Assets", "LicenseCount");
            DropColumn("Assets.Assets", "CapabilityId");
            DropColumn("Vendors.Contracts", "Location");
            DropColumn("Vendors.Contracts", "GeneralLedgerAccount");
            DropColumn("Vendors.Contracts", "MonthlyBudget");
            DropColumn("Vendors.Contracts", "YearlyBudget");
            DropColumn("Vendors.Contracts", "PriceBreaks");
            DropColumn("Vendors.Contracts", "PricingAmount");
            DropColumn("Vendors.Contracts", "PricingMethod");
            DropColumn("Vendors.Contracts", "LineOfBusiness");
            DropTable("TypeCodes.PricingMethods");
            DropTable("TypeCodes.Locations");
            DropTable("dbo.ContractComments");
        }
    }
}
