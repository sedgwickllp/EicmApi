using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;

namespace Eicm.BusinessLogic
{
    public interface IContractBusinessLogic
    {
        Task<ICommonResult<GetContractResponseModel>> GetContractByIdAsync(int id);
        Task<ICommonResult<int>> AddContractAsync(AddContractRequestModel contract);
    }
}
