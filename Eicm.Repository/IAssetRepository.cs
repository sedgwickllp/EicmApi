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
    public interface IAssetRepository
    {
        Task<ICommonResult<int>> AddAssetAsync(Asset asset);
        Task<ICommonResult<int>> AddAssetToContractAsync(int assetId, int contractId);
    }
}
