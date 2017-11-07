using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IVendorContractRepository
    {
        Task<ICommonResult<List<VendorContract>>> GetContractsByVendorIdAsync(int id);
        Task<ICommonResult<int>> AddContractToVendorAsync(int contractId, int vendorId, int userId);
        Task<ICommonResult<bool>> RemoveContractFromVendorAsync(int vendorContractId);
        /*Task<ICommonResult<bool>> UpdateVendorAsync(int vendorId, string vendorName, bool isActive, int userId);
        Task<ICommonResult<bool>> DeleteVendorAsync(int id);
        Task<ICommonResult<int>> AddContractAsync(Contract contract, int userId, int accountId);
        */
    }
}
