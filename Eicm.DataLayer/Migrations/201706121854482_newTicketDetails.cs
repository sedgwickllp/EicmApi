namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTicketDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("Tickets.TicketComments", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("Tickets.TicketComments", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("Tickets.TicketComments", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AddColumn("Tickets.Tickets", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("Tickets.Tickets", "CreatedByUserId", c => c.Int(nullable: false));
            AddColumn("Tickets.Tickets", "ModifiedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("Tickets.Tickets", "CauseId", c => c.Int());
            AlterColumn("Tickets.Tickets", "CategoryId", c => c.Int());
            AlterColumn("Tickets.Tickets", "SubCategoryId", c => c.Int());
            DropColumn("Tickets.TicketComments", "EnteredDate");
            DropColumn("Tickets.TicketComments", "EnteredByUserId");
            DropColumn("Tickets.TicketComments", "ModifiedDate");
            DropColumn("Tickets.Tickets", "EnteredDate");
            DropColumn("Tickets.Tickets", "EnteredByUserId");
            DropColumn("Tickets.Tickets", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("Tickets.Tickets", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("Tickets.Tickets", "EnteredByUserId", c => c.Int(nullable: false));
            AddColumn("Tickets.Tickets", "EnteredDate", c => c.DateTime(nullable: false));
            AddColumn("Tickets.TicketComments", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("Tickets.TicketComments", "EnteredByUserId", c => c.Int(nullable: false));
            AddColumn("Tickets.TicketComments", "EnteredDate", c => c.DateTime(nullable: false));
            AlterColumn("Tickets.Tickets", "SubCategoryId", c => c.Int(nullable: false));
            AlterColumn("Tickets.Tickets", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("Tickets.Tickets", "CauseId", c => c.Int(nullable: false));
            DropColumn("Tickets.Tickets", "ModifiedDateTime");
            DropColumn("Tickets.Tickets", "CreatedByUserId");
            DropColumn("Tickets.Tickets", "CreatedDateTime");
            DropColumn("Tickets.TicketComments", "ModifiedDateTime");
            DropColumn("Tickets.TicketComments", "CreatedByUserId");
            DropColumn("Tickets.TicketComments", "CreatedDateTime");
        }
    }
}
