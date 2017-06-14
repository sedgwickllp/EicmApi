namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTicketDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("Tickets.Tickets", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Tickets.Tickets", "IsDeleted");
        }
    }
}
