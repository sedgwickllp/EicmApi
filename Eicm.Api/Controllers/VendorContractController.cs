using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class VendorContractController : BaseApiController
    {
        //private readonly IVendorBusinessLogic _vendorsBusinessLogic;
        private readonly IVendorContractBusinessLogic _vendorContractBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public VendorContractController(IVendorContractBusinessLogic vendorContractBusinessLogic)
        {
            _vendorContractBusinessLogic = vendorContractBusinessLogic;
            //_contractBusinessLogic = contractBusinessLogic;
        }

        [HttpGet]
        [Route("api/vendors/{vendorId}/contracts")]
        public async Task<IHttpActionResult> GetVendorContracts(int vendorId)
        {
            _logger.Info("Retrieving contracts with vendor id = " + vendorId);
            try
            {
                var vendorContracts = await _vendorContractBusinessLogic.GetContractsByVendorIdAsync(vendorId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (vendorContracts.Payload == null)
                {
                    return NotFound();
                }

                return Ok(vendorContracts.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        


        [HttpPost]
        [Route("api/vendors/{vendorId}/contracts/{contractId}")]
        public async Task<IHttpActionResult> Add(int vendorId, int contractId)
        {
           

            int userId = 1; //TODO get user profile
            _logger.Info("Adding contract to  vendor");

            var vendor = await _vendorContractBusinessLogic.AddContractToVendorAsync(contractId, vendorId, userId); //TODO change to user object vs id?
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vendor);
        }
        
        [HttpDelete]
        [Route("api/vendors/{vendorId}/contracts/{contractId}")]
        public async Task<IHttpActionResult> Delete(int vendorId, int contractId)
        {
            _logger.Info("Deleting vendor with id = " + vendorId);
            
            await _vendorContractBusinessLogic.RemoveContractFromVendorAsync(vendorId);
            return Ok(vendorId);
        }

        /* [HttpPost]
         [Route("api/vendors/{vendorId}/contracts/")]
         public async Task<IHttpActionResult> Add([FromBody] ContractAddModel contract)
         {
             if (contract == null)
             {
                 return BadRequest("Contract is null");
             }

             int userId = 1; //TODO get user profile
             _logger.Info("Adding contract");

             var newContract = await _vendorsBusinessLogic.AddContractAsync(contract, vendorId); //TODO change to user object vs id?
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             return Ok(newContract);
         }*/
    }
}