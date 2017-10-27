using System;
using System.Threading.Tasks;
using System.Web.Http;
using Eicm.BusinessLogic;
using Eicm.BusinessLogic.DataObjects;
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

       /* [HttpGet]
        [Route("api/asset/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            _logger.Info("Retrieving contract with id = " + id);
            try
            {
                var asset = await _assetsBusinessLogic.GetAssetByIdAsync(id);

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
        }*/

        [HttpPost]
        [Route("api/asset/")]
        public async Task<IHttpActionResult> Add([FromBody] AssetModel asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset is null");
            }


            _logger.Info("Adding asset");

            var newAsset = await _assetsBusinessLogic.AddAssetAsync(asset); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(newAsset);
        }

        
    }
}