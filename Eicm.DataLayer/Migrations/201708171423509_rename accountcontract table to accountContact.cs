namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameaccountcontracttabletoaccountContact : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Vendors.AccountContracts", newName: "AccountContacts");
        }
        
        public override void Down()
        {
            RenameTable(name: "Vendors.AccountContacts", newName: "AccountContracts");
        }
    }
}
