using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
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

        public async Task<ICommonResult<List<UserModel>>> GetUsersAsync()
        {
            _logger.Info("Retrieving all users");
            var dbuserList = await _userRepository.GetActiveUsersAsync();

            if (dbuserList.ResultCode)
            {
                var userList = dbuserList.Payload.Select(user => new UserModel(user)).ToList();
                return new CommonResult<List<UserModel>>(userList, dbuserList.ResultCode);
            }

            return new CommonResult<List<UserModel>>(null, dbuserList.ResultCode, dbuserList.Message);
        }

        public async Task<ICommonResult<List<UserProfileModel>>> GetUserProfilesAsync()
        {
            _logger.Info("Retrieving all users");
            var dbuserList = await _userRepository.GetActiveUserProfilesAsync();

            if (dbuserList.ResultCode)
            {
                var userList = dbuserList.Payload.Select(user => new UserProfileModel(user)).ToList();
                return new CommonResult<List<UserProfileModel>>(userList, dbuserList.ResultCode);
            }

            return new CommonResult<List<UserProfileModel>>(null, dbuserList.ResultCode, dbuserList.Message);
        }
        public async Task<ICommonResult<int>> AddUserAsync(string userName)
        {
            var existingUser = await _userRepository.GetUserByUserNameAsync(userName);
            if (existingUser.Payload == null)
            {
                var ctx = new PrincipalContext(ContextType.Domain);
                var adUser = UserPrincipal.FindByIdentity(ctx, userName);
                if (adUser == null) return new CommonResult<int>(-1, ResultCode.Failure, "User not found in AD");
                var directoryEntry = adUser.GetUnderlyingObject() as DirectoryEntry;
                if (adUser.Guid == null) return new CommonResult<int>(-1, ResultCode.Failure, "User not found in AD");
                if (directoryEntry == null) return new CommonResult<int>(-1, ResultCode.Failure, "User already exists");
                var userId = await _userRepository.AddUserAsync(
                    adUser.Guid,
                    adUser.SamAccountName,
                    adUser.EmailAddress,
                    adUser.GivenName,
                    adUser.Surname,
                    directoryEntry.Properties["l"].Value.ToString(),
                    Convert.ToInt32(directoryEntry.Properties["ipPhone"].Value),
                    Convert.ToInt32(directoryEntry.Properties["MobilePhone"].Value)

                );
                return new CommonResult<int>(userId.Payload, userId.ResultCode);
            }
            
            
            return new CommonResult<int>(-1, ResultCode.Failure, "User already exists");
        }
    }
}
