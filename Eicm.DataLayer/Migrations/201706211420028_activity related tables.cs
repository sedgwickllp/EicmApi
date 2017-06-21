namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activityrelatedtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TypeCodes.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tickets.TicketActivities",
                c => new
                    {
                        TicketActivityId = c.Int(nullable: false, identity: true),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        TicketPropertyId = c.Int(nullable: false),
                        FromValue = c.String(),
                        ToValue = c.String(),
                    })
                .PrimaryKey(t => t.TicketActivityId);
            
            CreateTable(
                "TypeCodes.TicketProperties",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TypeCodes.TicketProperties");
            DropTable("Tickets.TicketActivities");
            DropTable("TypeCodes.Activities");
        }
    }
}
