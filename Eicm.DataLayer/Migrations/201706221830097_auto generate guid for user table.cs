namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autogenerateguidforusertable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("Users.Users");
            AlterColumn("Users.Users", "UserId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("Users.Users", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("Users.Users");
            AlterColumn("Users.Users", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("Users.Users", "UserId");
        }
    }
}
