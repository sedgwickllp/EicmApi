using System.Data.Entity;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.DataLayer
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        public CoreDbContext(): base("name=CoreDbContext")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<TicketActivity> TicketActivities { get; set; }
        public virtual DbSet<TicketProperty> TicketProperties { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketHistory> TicketHistories { get; set; }
        public virtual DbSet<TicketComment> TicketComments { get; set; }
        public virtual DbSet<TicketCommentHistory> TicketCommentHistories { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Cause> Causes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}