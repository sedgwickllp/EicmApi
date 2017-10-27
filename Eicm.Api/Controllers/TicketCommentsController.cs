using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class TicketCommentsController : BaseApiController
    {
        private readonly ITicketCommentsBusinessLogic _ticketCommentsBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public TicketCommentsController(ITicketCommentsBusinessLogic ticketCommentsBusinessLogic)
        {
            _ticketCommentsBusinessLogic = ticketCommentsBusinessLogic;
        }

        [HttpGet]
        [Route("api/ticketComments/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving ticket note with id = " + id);
            try
            {

                var ticketComment = await _ticketCommentsBusinessLogic.GetTicketNoteByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ticketComment.Payload == null)
                {
                    return NotFound();
                }
                return Ok(ticketComment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ticketComments/")]
        public async Task<IHttpActionResult> Get()
        {
            _logger.Info("Retrieving all ticket notes");

            try
            {

                var ticketComments = await _ticketCommentsBusinessLogic.GetTicketNotesAsync();


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ticketComments.Payload == null)
                {
                    return NotFound();
                }
                return Ok(ticketComments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ticketComments/")]
        public async Task<IHttpActionResult> Add([FromBody] TicketCommentAddModel ticketComment)
        {
            if (ticketComment == null)
            {
                return BadRequest("Ticket object was null");
            }
            if (ticketComment.Comment == null)
            {
                return BadRequest("Comment cannot be null");
            }
            int userId = 1; //TODO change to get userId
            _logger.Info("Adding ticketNote");

            var ticketNoteId = await _ticketCommentsBusinessLogic.AddTicketCommentAsync(ticketComment, userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ticketNoteId);
        }

    }
}