namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vendorupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountContacts", "AccountId");
            CreateIndex("dbo.AccountContacts", "ContactId");
            CreateIndex("Vendors.Accounts", "VendorId");
            CreateIndex("dbo.Contracts", "AccountId");
            AddForeignKey("dbo.AccountContacts", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AccountContacts", "AccountId", "Vendors.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "AccountId", "Vendors.Accounts", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.Accounts", "VendorId", "dbo.Vendors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.Accounts", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Contracts", "AccountId", "Vendors.Accounts");
            DropForeignKey("dbo.AccountContacts", "AccountId", "Vendors.Accounts");
            DropForeignKey("dbo.AccountContacts", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Contracts", new[] { "AccountId" });
            DropIndex("Vendors.Accounts", new[] { "VendorId" });
            DropIndex("dbo.AccountContacts", new[] { "ContactId" });
            DropIndex("dbo.AccountContacts", new[] { "AccountId" });
            DropColumn("dbo.Contracts", "AccountId");
        }
    }
}
