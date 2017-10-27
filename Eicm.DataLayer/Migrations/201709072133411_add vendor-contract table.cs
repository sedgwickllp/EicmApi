namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvendorcontracttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Vendors.VendorContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Vendors.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.VendorContracts", "ContractId", "Vendors.Contracts");
            DropIndex("Vendors.VendorContracts", new[] { "ContractId" });
            DropTable("Vendors.VendorContracts");
        }
    }
}
