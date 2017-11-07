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
            var dbAsset = new Asset()
            {
                Description = asset.Description,
                Name = asset.Name,
                LicenseCount = asset.LicenseCount,
                CapabilityId = asset.CapabilityId,


                ModifedByUserId = asset.ModifedByUserId,
                ModifiedDateTime = asset.ModifiedDateTime,
                CreatedByUserId = asset.CreatedByUserId,
                CreatedDateTime = asset.CreatedDateTime
            };
            var newAsset = await _assetRepository.AddAssetAsync(dbAsset);
            return new CommonResult<int>(newAsset.Payload, newAsset.ResultCode);
        }

       
    }
}
