using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core;
using Eicm.Core.Enums;

namespace Eicm.Api.Controllers
{
    public class TicketsController : BaseApiController
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly ITicketBusinessLogic _ticketBusinessLogic;
        public TicketsController(ITicketBusinessLogic ticketBusinessLogic)
        {
            _ticketBusinessLogic = ticketBusinessLogic;
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving ticket with id = " + id);
            try
            {
                var ticket = await _ticketBusinessLogic.GetTicketDtoByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ticket == null)
                {
                    return NotFound();
                }

                return Ok(ticket.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/tickets/user/{userId}")]
        public async Task<IHttpActionResult> GetByUser(int userId)
        {
            _logger.Info("Retrieving ticket for user with id = " + userId);
            try
            {
                var ticket = await _ticketBusinessLogic.GetTicketsByUserIdAsync(userId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ticket == null)
                {
                    return NotFound();
                }

                return Ok(ticket.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/tickets")]
        public async Task<IHttpActionResult> Get()
        {
            _logger.Info("Retrieving all tickets");

            var tickets = await _ticketBusinessLogic.GetTicketsAsync();

            return Ok(tickets.Payload);
        }

        [HttpDelete]
        [Route("api/tickets/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            _logger.Info("Deleting ticket id = " + id);
            try
            {
                await _ticketBusinessLogic.DeleteTicketByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }


            return Ok(id);
        }

        [HttpPost]
        [Route("api/tickets/")]
        public async Task<IHttpActionResult> Add([FromBody] TicketAddDTO ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Ticket object was null");
            }
            if (ticket.Summary == null)
            {
                return BadRequest("Description of the ticket cannot be null");
            }
            int userId = 1; //TODO get user profile
            _logger.Info("Adding ticket");

            var ticketId = await _ticketBusinessLogic.AddTicketAsync(ticket, userId); //TODO change to user object vs id?
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ticketId);
        }

        [HttpPut]
        [Route("api/tickets/{id}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] TicketDetailModel ticket)
        {
            _logger.Info("Updating ticket with id = " + id);
            //if (ticket.TicketId != id)
            //{
            //    _logger.Info("Tried to update ticket with mismatched ids. id = " + id + " and ticket.id " + ticket.Id);
            //    return BadRequest("Id does not match Id from object");

            //}
            int? causeId = null;
            if (!string.IsNullOrEmpty(ticket.Cause))
            {
                causeId = AttributeMethods.GetByDisplayed<CauseType>(ticket.Cause).GetHashCode();
            }

            int? categoryId = null;
            if (!string.IsNullOrEmpty(ticket.Category))
            {
                categoryId = AttributeMethods.GetByDisplayed<CategoryType>(ticket.Category).GetHashCode();
            }

            int? subCategoryId = null;
            if (!string.IsNullOrEmpty(ticket.SubCategory))
            {
                subCategoryId = AttributeMethods.GetByDisplayed<SubCategoryType>(ticket.SubCategory).GetHashCode();
            }

            var ticketAdd = new TicketAddDTO
            {
                Summary = ticket.Summary,
                RequesterId = null,
                OwnerId = null,
                CauseId = causeId,
                StatusId = AttributeMethods.GetByDisplayed<StatusType>(ticket.Status).GetHashCode(),
                PriorityId = AttributeMethods.GetByDisplayed<PriorityType>(ticket.Priority).GetHashCode(),
                OriginId = AttributeMethods.GetByDisplayed<OriginType>(ticket.Origin).GetHashCode(),
                CategoryId = categoryId,
                SubcategoryId = subCategoryId,
                IsConfidential = ticket.IsConfidential

            };
            var ticketId = await _ticketBusinessLogic.UpdateTicketAsync(id, ticketAdd);

            return Ok(ticketId);
        }
    }
}