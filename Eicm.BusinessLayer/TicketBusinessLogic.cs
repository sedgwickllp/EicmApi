using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class TicketBusinessLogic : ITicketBusinessLogic
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TicketBusinessLogic(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<ICommonResult<TicketModel>> GetTicketByIdAsync(int id)
        {
            _logger.Info("Retrieving ticket id: " + id);
            var dbticket = await _ticketRepository.GetTicketByIdAsync(id);

            if (dbticket.ResultCode && dbticket.Payload == null)
            {
                _logger.Info("No ticket returned for id: " + id);
                return new CommonResult<TicketModel>(null, dbticket.ResultCode);
            }
            if (!dbticket.ResultCode)
            {
                _logger.Info("getTicketByIdAsync returned failed from repo");
                return new CommonResult<TicketModel>(null, dbticket.ResultCode, dbticket.Message);
            }
            _logger.Info("Ticket retrieved");

            return new CommonResult<TicketModel>(new TicketModel(dbticket.Payload), dbticket.ResultCode); ;
        }

        public async Task<ICommonResult<TicketDTO>> GetTicketDtoByIdAsync(int id)
        {
            _logger.Info("Retrieving ticket id: " + id);
            var dbticket = await _ticketRepository.GetTicketByIdAsync(id);
            
            var ticket = new TicketDTO();
            //ticket.TicketDetail = new TicketDetailModel(dbticket.Payload.Id, dbticket.Payload.Description);
            //ticket.TicketRequester = new TicketRequesterModel(dbticket.Payload.RequestedBy, "test", "email", "1111111111", "KC");
            ticket.TicketDetail = new TicketDetailModel(dbticket.Payload);
            //ticket.TicketDetail = new TicketDetailModel(id, "Software", "Outlook", "Password Reset", "04/21/2017", "Open", "High", "Email", "descripton from service");
            ticket.TicketRequester = new TicketRequesterModel("Han", "Solo", "han.solo@milleniumfalcon.com", "111-111-1111", "Kansas City, USA");
            ticket.TicketActivity = new List<TicketActivityModel>();
            ticket.TicketActivity.Add(new TicketActivityModel("Princess Leia", "April 30 3:30pm", "created ticket", false, true, false));
            ticket.TicketActivity.AddRange(dbticket.Payload.Comments?.Select(x => new TicketActivityModel(dbticket.Payload.Comments.IndexOf(x) % 2 == 0 ? "Luke Skywalker" : "Princess Leia", x.CreatedDateTime.ToString("MMMM dd h:mm tt"), "comment added", true, false, false)));
            ticket.TicketComments = dbticket.Payload.Comments?.Select(x => new TicketCommentsModel(dbticket.Payload.Comments.IndexOf(x) % 2 == 0 ? "Luke Skywalker" : "Princess Leia", x.CreatedDateTime.ToString("MM/dd/yyyy") , x.Comment, x.IsVisibleToAll)).ToList();
            //ticket.TicketComments = new List<TicketCommentsModel>();
            //ticket.TicketComments.Add(new TicketCommentsModel("Princess Leia", "04/20/2017", "May the force be with you"));
            return new CommonResult<TicketDTO>(ticket, true); ;
        }

        public async Task<ICommonResult<List<TicketModel>>> GetTicketsAsync()
        {
            _logger.Info("Retrieving all tickets");
            var dbticketList = await _ticketRepository.GetActiveTicketsAsync();

            if (dbticketList.ResultCode)
            {
                var ticketList = dbticketList.Payload.Select(ticket => new TicketModel(ticket)).ToList();
                return new CommonResult<List<TicketModel>>(ticketList, dbticketList.ResultCode);
            }

            return new CommonResult<List<TicketModel>>(null, dbticketList.ResultCode, dbticketList.Message);
        }

        public async Task<ICommonResult<int>> AddTicketAsync(TicketAddDTO ticket, int userId)
        {

            //TODO create user profile and include isVip
            bool isUserVip = false;

            var ticketId = await _ticketRepository.AddTicketAsync(ticket.Summary, ticket.RequesterId ?? userId, ticket.OwnerId, ticket.CauseId, ticket.StatusId ?? StatusType.Open.GetHashCode(), 
                ticket.PriorityId ?? PriorityType.Medium.GetHashCode(), ticket.OriginId, ticket.CategoryId, ticket.SubcategoryId, ticket.IsConfidential, isUserVip, userId);
            return new CommonResult<int>(ticketId.Payload, ticketId.ResultCode);
        }

        public async Task<ICommonResult<bool>> UpdateTicketAsync(TicketModel ticket)
        {

            var dbticket = PopulateTicket(ticket);

            var ticketId = await _ticketRepository.UpdateTicketAsync(dbticket);
            return new CommonResult<bool>(ticketId.ResultCode);

        }
        public async Task<ICommonResult<bool>> DeleteTicketByIdAsync(int id)
        {
            var dbticket = await _ticketRepository.DeleteTicketAsync(id);

            return new CommonResult<bool>(dbticket.ResultCode);
        }

        private Ticket PopulateTicket(TicketModel dtoTicket)
        {
            var ticket = new Ticket
            {
                Id = dtoTicket.Id,
                //RequestedBy = dtoTicket.Requestor,
                Summary = dtoTicket.Summary,
                CategoryId = AttributeMethods.GetByDisplayed<PriorityType>(dtoTicket.Category).GetHashCode(),//dtoTicket.Category,
                StatusId = AttributeMethods.GetByDisplayed<PriorityType>(dtoTicket.Status).GetHashCode(),//dtoTicket.Status,
                IsActive = dtoTicket.IsDeleted,
                ModifiedDateTime = dtoTicket.ModifiedDate,
                //Owner = dtoTicket.Owner,
                PriorityId = AttributeMethods.GetByDisplayed<PriorityType>(dtoTicket.Priority).GetHashCode(),
                //Notes =  TicketNoteBusinessLogic.PopulateNote(dbticket.Notes),
                CreatedDateTime = dtoTicket.CreatedDateTime
            };

            return ticket;
        }

    }
}
