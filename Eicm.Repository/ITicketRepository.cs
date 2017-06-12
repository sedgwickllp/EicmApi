using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Tickets;

namespace Eicm.Repository
{
    public interface ITicketRepository
    {
        Task<ICommonResult<Ticket>> GetTicketByIdAsync(int id);
        Task<ICommonResult<List<Ticket>>> GetTicketsAsync();
        Task<ICommonResult<List<Ticket>>> GetActiveTicketsAsync();
        Task<ICommonResult<int>> AddTicketAsync(string summary, int requesterId, int? ownerId, int? causeId,
            int statusId, int priorityId, int originId, int? categoryId, int? subcategoryId, bool isConfidential, bool isVip, int userId);
        Task<ICommonResult<bool>> UpdateTicketAsync(Ticket ticket);
        Task<ICommonResult<bool>> DeleteTicketAsync(int id);
        void Dispose();
    }
}