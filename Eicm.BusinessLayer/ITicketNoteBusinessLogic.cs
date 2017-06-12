using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eicm.BusinessLogic
{
    public interface ITicketNoteBusinessLogic
    {
        Task<ICommonResult<TicketNoteModel>> GetTicketNoteByIdAsync(int id);
       
        Task<ICommonResult<List<TicketNoteModel>>> GetTicketNotesAsync();
        Task<ICommonResult<bool>> DeleteTicketNoteByIdAsync(int id);
        Task<ICommonResult<int>> AddTicketNoteAsync(TicketNoteModel ticket);
        Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketNoteModel ticket);
    }
}