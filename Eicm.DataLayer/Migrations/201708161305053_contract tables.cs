namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contracttables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Vendors.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Assets.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetTypeId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Capability = c.String(),
                        Description = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Assets.AssetTypes",
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
                "TypeCodes.Capabilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.ContactCodes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ContactType = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractAssets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        AssetId = c.Int(nullable: false),
                        LicenseType = c.Int(nullable: false),
                        LicenseCount = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.ContractGlobalStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TermStartDate = c.DateTime(nullable: false),
                        TermEndDate = c.DateTime(nullable: false),
                        Terms = c.String(),
                        ExitConditions = c.String(),
                        EarlyExitDate = c.DateTime(nullable: false),
                        ContractStatus = c.Int(nullable: false),
                        OverallStatus = c.Int(nullable: false),
                        WorkflowStatus = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.ContractStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.DataStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.DollarThresholds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.LineOfBusinesses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.ProductDispositions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
            DropTable("TypeCodes.Vendors");
            DropTable("TypeCodes.ProductDispositions");
            DropTable("TypeCodes.LineOfBusinesses");
            DropTable("TypeCodes.Licenses");
            DropTable("TypeCodes.DollarThresholds");
            DropTable("TypeCodes.DataStatuses");
            DropTable("TypeCodes.ContractStatuses");
            DropTable("dbo.Contracts");
            DropTable("TypeCodes.ContractGlobalStatuses");
            DropTable("dbo.ContractAssets");
            DropTable("dbo.Contacts");
            DropTable("TypeCodes.ContactCodes");
            DropTable("TypeCodes.Capabilities");
            DropTable("Assets.AssetTypes");
            DropTable("Assets.Assets");
            DropTable("Vendors.Accounts");
            DropTable("dbo.AccountContacts");
        }
    }
}
