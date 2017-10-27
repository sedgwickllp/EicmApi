namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyvendortablesagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("Assets.Assets", "Name", c => c.String());
            DropColumn("Assets.Assets", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("Assets.Assets", "ProductName", c => c.String());
            DropColumn("Assets.Assets", "Name");
        }
    }
}
