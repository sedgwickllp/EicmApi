using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.Users;
using Eicm.DataLayer.Migrations;
using NLog;

namespace Eicm.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public UserRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<User>> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var foundUser = await _coreDbContext.Users.SingleAsync(t => t.UserName == userName);
                return new CommonResult<User>(foundUser, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<User>(null, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<UserProfile>> GetUserProfileByIdAsync(int userId)
        {
            try
            {
                var foundUser = await _coreDbContext.UserProfiles.SingleAsync(t => t.User.Id == userId);
                return new CommonResult<UserProfile>(foundUser, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<UserProfile>(null, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<List<User>>> GetActiveUsersAsync()
        {
            try
            {
                var users = await _coreDbContext.Users.Where(user => user.IsActive).OrderBy(c => c.FirstName).ToListAsync();
                return new CommonResult<List<User>>(users, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<User>>(null, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<List<UserProfile>>> GetActiveUserProfilesAsync()
        {
            try
            {
                var users = await _coreDbContext.UserProfiles.Where(user => user.User.IsActive).OrderBy(c => c.User.FirstName).ToListAsync();
                return new CommonResult<List<UserProfile>>(users, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<UserProfile>>(null, ResultCode.Failure, ex.Message);
            }

        }
        public async Task<ICommonResult<int>> AddUserAsync(Guid? adId, string userName, string email, string firstName, string lastName, string location, int phoneExt, int cellPhone)
        {
            try
            {
                var newUser = new User
                {
                    AdId = adId,
                    UserName = userName,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    IsActive = true,
                    CreatedByUserId = 1,
                    ModifedByUserId = 1
                    
                    
                };
                _coreDbContext.Users.Add(newUser);
                await _coreDbContext.SaveChangesAsync();
                var newProfile = new UserProfile
                {
                    UserId = newUser.Id,
                    BusinessExtension = phoneExt,
                    CellPhoneNumber = cellPhone,
                    UserLocationId = 1,
                    ModifedByUserId = newUser.Id,
                    ModifiedDateTime = DateTime.Now,
                    CreatedDateTime = DateTime.Now,
                    CreatedByUserId = newUser.Id
                };
                _coreDbContext.UserProfiles.Add(newProfile);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(newUser.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }
        public void Dispose()
        {
            _coreDbContext?.Dispose();
        }
    }
}
