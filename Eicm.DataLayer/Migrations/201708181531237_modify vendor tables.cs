namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyvendortables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Vendors.Contracts", "PricingAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("Vendors.Contracts", "PricingAmount", c => c.Int());
        }
    }
}
