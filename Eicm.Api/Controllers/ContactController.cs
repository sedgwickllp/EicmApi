using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class ContactController : BaseApiController
    {
        private readonly IContactBusinessLogic _contactBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContactController(IContactBusinessLogic contactBusinessLogic)
        {
            _contactBusinessLogic = contactBusinessLogic;
        }

        [HttpGet]
        [Route("api/contacts/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving contact with id = " + id);
            try
            {
                var contact = await _contactBusinessLogic.GetContactByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (contact.Payload == null)
                {
                    return NotFound();
                }

                return Ok(contact.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
		

        [HttpPost]
        [Route("api/contacts/")]
        public async Task<IHttpActionResult> Add([FromBody] ContactDTO contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact is null");
            }

            
            _logger.Info("Adding contact");

            var newContact = await _contactBusinessLogic.AddContactAsync(contact); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newContact);
        }
       
    }
}