using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IAssetBusinessLogic
    {
        Task<ICommonResult<int>> AddAssetAsync(AssetModel asset);
        Task<ICommonResult<int>> AddAssetToContractAsync(AssetModel asset, int contractId);
    }
}
