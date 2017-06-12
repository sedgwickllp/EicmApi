using System.Data.Entity;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.DataLayer
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        public CoreDbContext(): base("name=CoreDbContext")
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketComment> TicketComments { get; set; }
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