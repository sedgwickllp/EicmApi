namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontracttablechangeyearlybudgettocost : DbMigration
    {
        public override void Up()
        {
            AddColumn("Vendors.Contracts", "Cost", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("Vendors.Contracts", "YearlyBudget");
        }
        
        public override void Down()
        {
            AddColumn("Vendors.Contracts", "YearlyBudget", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("Vendors.Contracts", "Cost");
        }
    }
}
