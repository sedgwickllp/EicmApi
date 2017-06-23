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

        public async Task<ICommonResult<int>> AddUserAsync(Guid? userId, string userName, string email, string firstName, string lastName)
        {
            try
            {
                var newUser = new User
                {
                    UserId = userId,
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
