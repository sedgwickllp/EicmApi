using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Eicm.BusinessLogic;
using NLog;

namespace Eicm.Api.Controllers
{
    public class TypeCodesController : BaseApiController
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [Route("api/typecodes/{typecode}")]
        public async Task<IHttpActionResult> Get(string typecode)
        {
            _logger.Info("Retrieving Enum values");
            try
            {
                var typeCodeList = TypeCodesBusinessLogic.GetTypeCodeValues(typecode);
                if (typeCodeList.Payload == null)
                {
                    return NotFound();
                }
                return Ok(typeCodeList);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Problem occured while retrieving typeCodes");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/typecodes")]
        public async Task<IHttpActionResult> Get()
        {
            _logger.Info("seeding Enum values");
            //_seedEnumsRepository.SeedUpdateEnums();
            //
            return Ok(TypeCodesBusinessLogic.GetAllTypeCodeValues());
        }

    }
}