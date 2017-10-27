namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontracttablenullablefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Vendors.Contracts", "TermStartDate", c => c.DateTime());
            AlterColumn("Vendors.Contracts", "TermEndDate", c => c.DateTime());
            AlterColumn("Vendors.Contracts", "EarlyExitDate", c => c.DateTime());
            AlterColumn("Vendors.Contracts", "PricingMethod", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("Vendors.Contracts", "PricingMethod", c => c.Int(nullable: false));
            AlterColumn("Vendors.Contracts", "EarlyExitDate", c => c.DateTime(nullable: false));
            AlterColumn("Vendors.Contracts", "TermEndDate", c => c.DateTime(nullable: false));
            AlterColumn("Vendors.Contracts", "TermStartDate", c => c.DateTime(nullable: false));
        }
    }
}
