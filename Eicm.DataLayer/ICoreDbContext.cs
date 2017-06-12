using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.DataLayer
{
    public interface ICoreDbContext : IDisposable
    {
        DbSet<Ticket> Tickets { get; set; }
        DbSet<TicketComment> TicketComments { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<Origin> Origins { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Cause> Causes { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }

        Task<int> SaveChangesAsync();
    }
}