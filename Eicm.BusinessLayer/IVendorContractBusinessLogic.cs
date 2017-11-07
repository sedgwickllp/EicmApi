using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IVendorContractBusinessLogic
    {
       
        Task<ICommonResult<bool>> RemoveContractFromVendorAsync(int id);
        Task<ICommonResult<VendorContractModel>> GetContractsByVendorIdAsync(int id);
        Task<ICommonResult<int>> AddContractToVendorAsync(int contractId, int vendorId, int userId);
    }
}
