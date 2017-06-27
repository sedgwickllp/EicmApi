namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Users.UserProfiles", "UserLocationId", c => c.Int(nullable: false));
            AddColumn("Users.Users", "AdId", c => c.Guid());
            DropColumn("Users.UserProfiles", "UserId");
            AddColumn("Users.UserProfiles", "UserId", c => c.Int(nullable: false));
            CreateIndex("Users.UserProfiles", "UserId");
            CreateIndex("Users.UserProfiles", "UserLocationId");
            AddForeignKey("Users.UserProfiles", "UserId", "Users.Users", "Id", cascadeDelete: true);
            AddForeignKey("Users.UserProfiles", "UserLocationId", "Users.UserLocations", "Id", cascadeDelete: true);
            DropColumn("Users.UserProfiles", "LocationId");
            DropColumn("Users.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("Users.Users", "UserId", c => c.Guid());
            AddColumn("Users.UserProfiles", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("Users.UserProfiles", "UserLocationId", "Users.UserLocations");
            DropForeignKey("Users.UserProfiles", "UserId", "Users.Users");
            DropIndex("Users.UserProfiles", new[] { "UserLocationId" });
            DropIndex("Users.UserProfiles", new[] { "UserId" });
            AlterColumn("Users.UserProfiles", "UserId", c => c.Guid(nullable: false));
            DropColumn("Users.Users", "AdId");
            DropColumn("Users.UserProfiles", "UserLocationId");
        }
    }
}
