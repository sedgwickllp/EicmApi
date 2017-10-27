using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IVendorBusinessLogic
    {
        Task<ICommonResult<VendorDTO>> GetVendorByIdAsync(int id);
        Task<ICommonResult<List<VendorDetailModel>>> GetVendorsAsync();
        Task<ICommonResult<int>> AddVendorAsync(string name, int userId);
        Task<ICommonResult<bool>> UpdateVendorAsync(VendorUpdateModel vendor, int userId);
        Task<ICommonResult<bool>> DeleteVendorByIdAsync(int id);
    }
}
