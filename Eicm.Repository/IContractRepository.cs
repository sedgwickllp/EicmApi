using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IContractRepository
    {
        Task<ICommonResult<Contract>> GetContractByIdAsync(int id);
        Task<ICommonResult<List<AccountContract>>> GetAccountContractsAsync(int id);
       
        Task<ICommonResult<int>> AddContractAsync(Contract contract,  int vendorId);
        Task<ICommonResult<int>> AddAssetAsync(Asset asset,  int contractId);
    }
}
