namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisevendortablesnamespaces : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountContacts", newName: "AccountContracts");
            MoveTable(name: "dbo.AccountContracts", newSchema: "Vendors");
            MoveTable(name: "dbo.Contacts", newSchema: "Vendors");
            MoveTable(name: "dbo.Contracts", newSchema: "Vendors");
            MoveTable(name: "dbo.ContractAssets", newSchema: "Vendors");
            MoveTable(name: "dbo.Vendors", newSchema: "Vendors");
            AlterColumn("Vendors.Accounts", "AccountNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Vendors.Accounts", "AccountNumber", c => c.Int(nullable: false));
            MoveTable(name: "Vendors.Vendors", newSchema: "dbo");
            MoveTable(name: "Vendors.ContractAssets", newSchema: "dbo");
            MoveTable(name: "Vendors.Contracts", newSchema: "dbo");
            MoveTable(name: "Vendors.Contacts", newSchema: "dbo");
            MoveTable(name: "Vendors.AccountContracts", newSchema: "dbo");
            RenameTable(name: "dbo.AccountContracts", newName: "AccountContacts");
        }
    }
}
