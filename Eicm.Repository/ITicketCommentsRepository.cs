using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Tickets;

namespace Eicm.Repository
{
    public interface ITicketCommentsRepository
    {
        Task<ICommonResult<TicketComment>> GetTicketNoteByIdAsync(int id);
        Task<ICommonResult<List<TicketComment>>> GetTicketNotesAsync();
        Task<ICommonResult<int>> AddTicketCommentAsync(int ticketId, string comment, bool isVisibleToAll, int userId);
        Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketComment note);
        Task<ICommonResult<bool>> DeleteTicketNoteAsync(int id);
    }
}
