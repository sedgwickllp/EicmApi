namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaccountnumtocontracttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Vendors.Contracts", "AccountNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Vendors.Contracts", "AccountNumber");
        }
    }
}
