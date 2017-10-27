namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserprofileaddtitle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Tickets.TicketActivities", "CreatedByUserId", "Users.Users");
            DropForeignKey("Tickets.TicketActivities", "TicketId", "Tickets.Tickets");
            DropIndex("Tickets.TicketActivities", new[] { "CreatedByUserId" });
            DropIndex("Tickets.TicketActivities", new[] { "TicketId" });
            AddColumn("Users.UserProfiles", "Title", c => c.String());
            CreateIndex("Tickets.Tickets", "RequesterId");
            CreateIndex("Tickets.Tickets", "OwnerId");
            AddForeignKey("Tickets.Tickets", "OwnerId", "Users.Users", "Id");
            AddForeignKey("Tickets.Tickets", "RequesterId", "Users.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Tickets.Tickets", "RequesterId", "Users.Users");
            DropForeignKey("Tickets.Tickets", "OwnerId", "Users.Users");
            DropIndex("Tickets.Tickets", new[] { "OwnerId" });
            DropIndex("Tickets.Tickets", new[] { "RequesterId" });
            DropColumn("Users.UserProfiles", "Title");
            CreateIndex("Tickets.TicketActivities", "TicketId");
            CreateIndex("Tickets.TicketActivities", "CreatedByUserId");
            AddForeignKey("Tickets.TicketActivities", "TicketId", "Tickets.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("Tickets.TicketActivities", "CreatedByUserId", "Users.Users", "Id", cascadeDelete: true);
        }
    }
}
