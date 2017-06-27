using Eicm.BusinessLogic.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IUserBusinessLogic
    {
        Task<ICommonResult<UserModel>> GetUserByUserNameAsync(string userName);
        Task<ICommonResult<int>> AddUserAsync(string userName);
        Task<ICommonResult<List<UserModel>>> GetUsersAsync();
        Task<ICommonResult<List<UserProfileModel>>> GetUserProfilesAsync();
    }
}