using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eicm.BusinessLogic
{
    public interface ITicketCommentsBusinessLogic
    {
        Task<ICommonResult<TicketCommentModel>> GetTicketNoteByIdAsync(int id);
       
        Task<ICommonResult<List<TicketCommentModel>>> GetTicketNotesAsync();
        Task<ICommonResult<bool>> DeleteTicketNoteByIdAsync(int id);
        //Task<ICommonResult<int>> AddTicketCommentAsync(TicketCommentModel ticket);
        Task<ICommonResult<int>> AddTicketCommentAsync(TicketCommentAddModel comment, int userId);
        Task<ICommonResult<bool>> UpdateTicketNoteAsync(TicketCommentModel ticket);
    }
}