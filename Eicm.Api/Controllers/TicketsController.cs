using System;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;

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
    }
}