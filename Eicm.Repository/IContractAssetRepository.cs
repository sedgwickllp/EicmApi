using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.Core.Models.ResponseModels;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IContractAssetRepository
    {
 
        Task<ICommonResult<int>> AddAssetToContractAsync(int assetId, int contractId);
        Task<ICommonResult<GetContractAssetResponseModel>> GetContractAssetsAsync(int contractId);
        Task<ICommonResult<bool>> RemoveAssetFromContractAsync(int contractId, int assetId);
    }
}
