namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrelatedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserAssets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AssetId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        GroupId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TimeZone = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        BusinessExtension = c.Int(nullable: false),
                        CellPhoneNumber = c.Int(nullable: false),
                        MachineName = c.String(),
                        LocationId = c.Int(nullable: false),
                        Signature = c.String(),
                        UserImageId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        AdId = c.Int(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("Users.Users");
            DropTable("Users.UserProfiles");
            DropTable("Users.UserLocations");
            DropTable("Users.UserGroups");
            DropTable("Users.UserAssets");
            DropTable("Users.Roles");
            DropTable("Users.Groups");
        }
    }
}
