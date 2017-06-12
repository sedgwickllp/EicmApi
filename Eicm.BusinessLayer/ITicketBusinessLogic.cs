using Eicm.BusinessLogic.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface ITicketBusinessLogic
    {
        Task<ICommonResult<TicketModel>> GetTicketByIdAsync(int id);
       
        Task<ICommonResult<List<TicketModel>>> GetTicketsAsync();
        Task<ICommonResult<bool>> DeleteTicketByIdAsync(int id);
        Task<ICommonResult<int>> AddTicketAsync(TicketAddDTO ticket, int userId);
        Task<ICommonResult<bool>> UpdateTicketAsync(TicketModel ticket);
        Task<ICommonResult<TicketDTO>> GetTicketDtoByIdAsync(int id);
    }
}