using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IVendorRepository
    {
        Task<ICommonResult<Vendor>> GetVendorByIdAsync(int id);
        Task<ICommonResult<List<Vendor>>> GetVendorsAsync();
        Task<ICommonResult<int>> AddVendorAsync(string name, int userId);
        Task<ICommonResult<bool>> UpdateVendorAsync(int vendorId, string vendorName, bool isActive, int userId);
        Task<ICommonResult<bool>> DeleteVendorAsync(int id);
        Task<ICommonResult<int>> AddContractAsync(Contract contract, int userId, int accountId);
    }
}
