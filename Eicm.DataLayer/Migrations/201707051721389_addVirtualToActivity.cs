namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVirtualToActivity : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Tickets.TicketActivities", "CreatedByUserId");
            CreateIndex("Tickets.TicketActivities", "TicketId");
            AddForeignKey("Tickets.TicketActivities", "CreatedByUserId", "Users.Users", "Id", cascadeDelete: true);
            AddForeignKey("Tickets.TicketActivities", "TicketId", "Tickets.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Tickets.TicketActivities", "TicketId", "Tickets.Tickets");
            DropForeignKey("Tickets.TicketActivities", "CreatedByUserId", "Users.Users");
            DropIndex("Tickets.TicketActivities", new[] { "TicketId" });
            DropIndex("Tickets.TicketActivities", new[] { "CreatedByUserId" });
        }
    }
}
