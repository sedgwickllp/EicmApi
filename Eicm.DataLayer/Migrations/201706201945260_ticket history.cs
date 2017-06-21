namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tickethistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TicketsHistory.TicketComments",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        TicketCommentId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Comment = c.String(),
                        IsVisibleToAll = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId);
            
            CreateTable(
                "TicketsHistory.Tickets",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Summary = c.String(),
                        RequesterId = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        CauseId = c.Int(),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        OriginId = c.Int(nullable: false),
                        CategoryId = c.Int(),
                        SubCategoryId = c.Int(),
                        IsConfidential = c.Boolean(nullable: false),
                        IsVip = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId);
            
        }
        
        public override void Down()
        {
            DropTable("TicketsHistory.Tickets");
            DropTable("TicketsHistory.TicketComments");
        }
    }
}
