namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempIdforassettable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Assets.Assets", "TempId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Assets.Assets", "TempId");
        }
    }
}
