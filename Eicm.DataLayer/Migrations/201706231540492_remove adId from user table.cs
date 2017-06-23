namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeadIdfromusertable : DbMigration
    {
        public override void Up()
        {
            DropColumn("Users.Users", "AdId");
        }
        
        public override void Down()
        {
            AddColumn("Users.Users", "AdId", c => c.Int(nullable: false));
        }
    }
}
