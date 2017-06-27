using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Users;

namespace Eicm.Repository
{
    public interface IUserRepository
    {
        Task<ICommonResult<User>> GetUserByUserNameAsync(string userName);

        Task<ICommonResult<UserProfile>> GetUserProfileByIdAsync(int userId);
        Task<ICommonResult<int>> AddUserAsync(Guid? userId, string userName, string email, string firstName, string lastName,
            string location, int phoneExt, int cellPhone);

        Task<ICommonResult<List<User>>> GetActiveUsersAsync();
        Task<ICommonResult<List<UserProfile>>> GetActiveUserProfilesAsync();
        void Dispose();
    }
}