using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class ContractsController : BaseApiController
    {
        private readonly IContractBusinessLogic _contractsBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractsController(IContractBusinessLogic contractBusinessLogic)
        {
            _contractsBusinessLogic = contractBusinessLogic;
        }

        [HttpGet]
        [Route("api/contracts/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving contract with id = " + id);
            try
            {
                var contract = await _contractsBusinessLogic.GetContractByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (contract.Payload == null)
                {
                    return NotFound();
                }

                return Ok(contract.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
		

        [HttpPost]
        [Route("api/contracts/")]
        public async Task<IHttpActionResult> Add([FromBody] ContractAddDTO contract)
        {
            if (contract == null)
            {
                return BadRequest("Contract is null");
            }

            
            _logger.Info("Adding contract");

            var newContract = await _contractsBusinessLogic.AddContractAsync(contract); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newContract);
        }
        /*
               [HttpPost]
               [Route("api/vendors/{vendorId}/accounts/{accountId}/contracts/")]
              public async Task<IHttpActionResult> Add([FromBody] ContractAddModel contract, int accountId)
               {
                   if (contract == null)
                   {
                       return BadRequest("Contract is null");
                   }

                   int userId = 1; //TODO get user profile
                   _logger.Info("Adding contract");

                   var newContract = await _contractBusinessLogic.AddContractAsync(contract, userId, accountId); //TODO change to user object vs id?
                   if (!ModelState.IsValid)
                   {
                       return BadRequest(ModelState);
                   }
                   return Ok(newContract);
               }*/
    }
}