using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using NLog;

namespace Eicm.Api.Controllers
{
    public class ContractAssetsController : BaseApiController
    {
        private readonly IContractAssetBusinessLogic _contractAssetBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractAssetsController(IContractAssetBusinessLogic contractAssetBusinessLogic)
        {
            
            _contractAssetBusinessLogic = contractAssetBusinessLogic;
        }

        [HttpGet]
        [Route("api/contracts/{id}/assets")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving contract assets with contractId = " + id);
            try
            {
                var contract = await _contractAssetBusinessLogic.GetContractAssetsAsync(id);

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
        [Route("api/contract/{contractId}/asset/")]
        public async Task<IHttpActionResult> Add([FromBody] AssetModel asset, int contractId)
        {
            if (asset == null)
            {
                return BadRequest("Asset is null");
            }


            _logger.Info("Adding asset");

            var newAsset =
                await _contractAssetBusinessLogic.AddAssetToContractAsync(asset, contractId); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newAsset);
        }

        [HttpDelete]
        [Route("api/contract/{contractId}/asset/{assetId}")]
        public async Task<IHttpActionResult> Delete(int contractId, int assetId)
        {
            _logger.Info("removing asset from contract");

            var newAsset =
                await _contractAssetBusinessLogic.RemoveAssetFromContractAsync(contractId, assetId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newAsset);
        }

    }
}