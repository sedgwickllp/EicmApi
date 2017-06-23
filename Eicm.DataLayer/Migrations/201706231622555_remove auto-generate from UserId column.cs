namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeautogeneratefromUserIdcolumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("Users.Users");
            AlterColumn("Users.Users", "UserId", c => c.Guid());
            AddPrimaryKey("Users.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("Users.Users");
            AlterColumn("Users.Users", "UserId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("Users.Users", "UserId");
        }
    }
}
