using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IContractBusinessLogic
    {
        Task<ICommonResult<ContractDTO>> GetContractByIdAsync(int id);
        Task<ICommonResult<int>> AddContractAsync(VendorContractAddDTO contract);
    }
}
