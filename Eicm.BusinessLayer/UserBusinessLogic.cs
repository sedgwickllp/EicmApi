using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class UserBusinessLogic: IUserBusinessLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UserBusinessLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ICommonResult<UserModel>> GetUserByUserNameAsync(string userName)
        {
            var dbuser = await _userRepository.GetUserByUserNameAsync(userName);
            if (dbuser.ResultCode && dbuser.Payload == null)
            {
                _logger.Info("No user returned for userName: " + userName);
                return new CommonResult<UserModel>(null, dbuser.ResultCode);
            }
            if (!dbuser.ResultCode)
            {
                _logger.Info("getUserByIdAsync returned failed from repo");
                return new CommonResult<UserModel>(null, dbuser.ResultCode, dbuser.Message);
            }
            _logger.Info("User retrieved");
            return new CommonResult<UserModel>(new UserModel(dbuser.Payload), dbuser.ResultCode);
        }

        public async Task<ICommonResult<int>> AddUserAsync(string userName)
        {
            var existingUser = await _userRepository.GetUserByUserNameAsync(userName);
            if (existingUser.Payload == null)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                UserPrincipal adUser = UserPrincipal.FindByIdentity(ctx, userName);
                // directoryEntry = adUser.GetUnderlyingObject();
                if (adUser.Guid != null)
                {
                    var userId = await _userRepository.AddUserAsync(
                        adUser.Guid,
                        adUser.SamAccountName,
                        adUser.EmailAddress, 
                        adUser.GivenName, 
                        adUser.Surname
                        
                    );
                    return new CommonResult<int>(userId.Payload, userId.ResultCode); 
                } 
            }
            
            
            return new CommonResult<int>(-1, ResultCode.Failure, "User already exists");
        }
    }
}
