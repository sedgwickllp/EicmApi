namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyassettables : DbMigration
    {
        public override void Up()
        {
            AddColumn("Vendors.Contracts", "TempId", c => c.Int());
            AddColumn("Assets.Assets", "AvgDailyUsers", c => c.Int());
            AddColumn("Assets.Assets", "Version", c => c.String());
            AddColumn("Assets.Assets", "ModelYear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Assets.Assets", "ModelYear");
            DropColumn("Assets.Assets", "Version");
            DropColumn("Assets.Assets", "AvgDailyUsers");
            DropColumn("Vendors.Contracts", "TempId");
        }
    }
}
