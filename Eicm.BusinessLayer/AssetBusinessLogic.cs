using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class AssetBusinessLogic : IAssetBusinessLogic
    {
        private readonly IAssetRepository _assetRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public AssetBusinessLogic(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }
        
        public async Task<ICommonResult<int>> AddAssetAsync(AssetModel asset)
        {
            var dbAsset = new Asset();
            
            dbAsset.Description = asset.Description;
            dbAsset.Name = asset.Name;
            dbAsset.LicenseCount = asset.LicenseCount;
            dbAsset.CapabilityId = asset.CapabilityId;
            
            
            dbAsset.ModifedByUserId = asset.ModifedByUserId;
            dbAsset.ModifiedDateTime = asset.ModifiedDateTime;
            dbAsset.CreatedByUserId = asset.CreatedByUserId;
            dbAsset.CreatedDateTime = asset.CreatedDateTime;
            var newAsset = await _assetRepository.AddAssetAsync(dbAsset);
            return new CommonResult<int>(newAsset.Payload, newAsset.ResultCode);
        }

        public async Task<ICommonResult<int>> AddAssetToContractAsync(AssetModel asset, int contractId)
        {
            var newAsset = await AddAssetAsync(asset);
            var newContractAsset = await _assetRepository.AddAssetToContractAsync(newAsset.Payload, contractId);
            return new CommonResult<int>(newAsset.Payload, newContractAsset.ResultCode);
        }
    }
}
