using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Core.Models.ResponseModels;

namespace Eicm.BusinessLogic
{
    public interface IContractAssetBusinessLogic
    {
        //Task<ICommonResult<int>> AddAssetToContractAsync(AssetModel asset, int contractId);
        Task<ICommonResult<GetContractAssetResponseModel>> GetContractAssetsAsync(int contractId);
        Task<ICommonResult<bool>> RemoveAssetFromContractAsync(int contractId, int assetId);
    }
}
