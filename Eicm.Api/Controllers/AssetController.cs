using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Models.RequestModels;
using NLog;

namespace Eicm.Api.Controllers
{
    public class AssetsController : BaseApiController
    {
        private readonly IAssetBusinessLogic _assetsBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public AssetsController(IAssetBusinessLogic assetBusinessLogic)
        {
            _assetsBusinessLogic = assetBusinessLogic;
        }

        [HttpGet]
        [Route("api/software/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving software with id = " + id);
            try
            {
                var asset = await _assetsBusinessLogic.GetSoftwareByIdAsync(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (asset.Payload == null)
                {
                    return NotFound();
                }

                return Ok(asset.Payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/software/")]
        public async Task<IHttpActionResult> Add([FromBody] AddSoftwareRequestModel asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset is null");
            }


            _logger.Info("Adding asset");

            var newAsset = await _assetsBusinessLogic.AddSoftwareAsync(asset); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newAsset);
        }

        
    }
}