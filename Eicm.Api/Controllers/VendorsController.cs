using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class VendorsController : BaseApiController
    {
        private readonly IVendorBusinessLogic _vendorsBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public VendorsController(IVendorBusinessLogic vendorBusinessLogic)
        {
            _vendorsBusinessLogic = vendorBusinessLogic;
        }

        [HttpGet]
        [Route("api/vendors/{id}")]
        public async Task<IHttpActionResult> GetVendorById(int id)
        {
            _logger.Info("Retrieving vendor with id = " + id);
            try
            {
                var vendor = await _vendorsBusinessLogic.GetVendorByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (vendor.Payload == null)
                {
                    return NotFound();
                }

                return Ok(vendor.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/vendors")]
        public async Task<IHttpActionResult> GetVendors()
        {
            _logger.Info("Retrieving all vendors");

            var vendors = await _vendorsBusinessLogic.GetVendorsAsync();

            return Ok(vendors.Payload);
        }
        [HttpPost]
        [Route("api/vendors/")]
        public async Task<IHttpActionResult> Add([FromBody] String name)
        {
            if (name == null)
            {
                return BadRequest("Vendor name was null");
            }
            
            int userId = 1; //TODO get user profile
            _logger.Info("Adding vendor");

            var vendor = await _vendorsBusinessLogic.AddVendorAsync(name, userId); //TODO change to user object vs id?
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vendor);
        }

        [HttpPut]
        [Route("api/vendors/{vendorId}")]
        public async Task<IHttpActionResult> Update([FromBody] VendorUpdateModel vendor)
        {
            if (vendor == null)
            {
                return BadRequest("Vendor is null");
            }

            int userId = 1; //TODO get user profile
            _logger.Info("Updating Vendor");

            var updatedVendor = await _vendorsBusinessLogic.UpdateVendorAsync(vendor, userId); //TODO change to user object vs id?
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(updatedVendor);
        }

        [HttpDelete]
        [Route("api/vendors/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            _logger.Info("Deleting vendor with id = " + id);
            
            await _vendorsBusinessLogic.DeleteVendorByIdAsync(id);
            return Ok(id);
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