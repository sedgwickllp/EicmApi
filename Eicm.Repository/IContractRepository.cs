using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IContractRepository
    {
        Task<ICommonResult<GetContractResponseModel>> GetContractByIdAsync(int id);
       
        Task<ICommonResult<int>> AddContractAsync(AddContractRequestModel contract);
        Task<ICommonResult<bool>> DeleteContractAsync(int id);
    }
}
