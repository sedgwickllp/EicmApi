namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TypeCodes.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Causes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Origins",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TypeCodes.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tickets.TicketComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Comment = c.String(),
                        IsVisibleToAll = c.Boolean(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                        EnteredByUserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Tickets.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "Tickets.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Summary = c.String(nullable: false, maxLength: 200),
                        RequesterId = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        CauseId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        OriginId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        IsConfidential = c.Boolean(nullable: false),
                        IsVip = c.Boolean(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                        EnteredByUserId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifedByUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("TypeCodes.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("TypeCodes.Origins", t => t.OriginId, cascadeDelete: true)
                .Index(t => t.PriorityId)
                .Index(t => t.OriginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Tickets.Tickets", "OriginId", "TypeCodes.Origins");
            DropForeignKey("Tickets.Tickets", "PriorityId", "TypeCodes.Priorities");
            DropForeignKey("Tickets.TicketComments", "TicketId", "Tickets.Tickets");
            DropIndex("Tickets.Tickets", new[] { "OriginId" });
            DropIndex("Tickets.Tickets", new[] { "PriorityId" });
            DropIndex("Tickets.TicketComments", new[] { "TicketId" });
            DropTable("Tickets.Tickets");
            DropTable("Tickets.TicketComments");
            DropTable("TypeCodes.SubCategories");
            DropTable("TypeCodes.Statuses");
            DropTable("TypeCodes.Priorities");
            DropTable("TypeCodes.Origins");
            DropTable("TypeCodes.Causes");
            DropTable("TypeCodes.Categories");
        }
    }
}
