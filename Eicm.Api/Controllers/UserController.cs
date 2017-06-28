using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Eicm.BusinessLogic;
using NLog;

namespace Eicm.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IUserBusinessLogic _userBusinessLogic;
        public UserController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }
        [HttpGet]
        [Route("api/user/{userName}")]
        public async Task<IHttpActionResult> Get(string userName)
        {
            _logger.Info("Retrieving user values from AD");
            try
            {
                var user = await _userBusinessLogic.GetUserByUserNameAsync(userName);
                if (user.Payload == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Problem occured while retrieving AD user info");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/user/")]
        public async Task<IHttpActionResult> Get()
        {
            _logger.Info("retrieving all users");
            //_seedEnumsRepository.SeedUpdateEnums();

            try
            {
                var users = await _userBusinessLogic.GetUsersAsync();
                if (users.Payload == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Problem occured while retrieving user list");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/userProfile/")]
        public async Task<IHttpActionResult> GetProfile()
        {
            _logger.Info("retrieving all user profiles");
            //_seedEnumsRepository.SeedUpdateEnums();

            try
            {
                var users = await _userBusinessLogic.GetUserProfilesAsync();
                if (users.Payload == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Problem occured while retrieving user profile list");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/user/")]
        public async Task<IHttpActionResult> Add([FromBody] String userName)
        {
            _logger.Info("adding user with userName " + userName);
            if (userName != null)
            {
                var userId = await _userBusinessLogic.AddUserAsync(userName);
                if (userId.Payload == -1)
                {
                    return NotFound();
                }
                return Ok(userId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}