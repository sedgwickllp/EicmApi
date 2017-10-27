namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tieaccounttocontacts : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Vendors.VendorAddresses", "VendorId");
            CreateIndex("Vendors.VendorAddresses", "AddressId");
            AddForeignKey("Vendors.VendorAddresses", "AddressId", "Core.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.VendorAddresses", "VendorId", "Vendors.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.VendorAddresses", "VendorId", "Vendors.Vendors");
            DropForeignKey("Vendors.VendorAddresses", "AddressId", "Core.Addresses");
            DropIndex("Vendors.VendorAddresses", new[] { "AddressId" });
            DropIndex("Vendors.VendorAddresses", new[] { "VendorId" });
        }
    }
}
