namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyvendortoincludecontract : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Vendors.VendorContacts", "VendorId");
            CreateIndex("Vendors.VendorContracts", "VendorId");
            AddForeignKey("Vendors.VendorContacts", "VendorId", "Vendors.Vendors", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.VendorContracts", "VendorId", "Vendors.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.VendorContracts", "VendorId", "Vendors.Vendors");
            DropForeignKey("Vendors.VendorContacts", "VendorId", "Vendors.Vendors");
            DropIndex("Vendors.VendorContracts", new[] { "VendorId" });
            DropIndex("Vendors.VendorContacts", new[] { "VendorId" });
        }
    }
}
