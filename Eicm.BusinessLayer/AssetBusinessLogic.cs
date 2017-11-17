using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;
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
        
       // public async Task<ICommonResult<int>> AddAssetAsync(AssetModel asset)
       // {
           /* var dbAsset = new Asset()
            {
                Description = asset.Description,
                Name = asset.Name,
                LicenseCount = asset.LicenseCount,
                CapabilityId = asset.CapabilityId,


                ModifedByUserId = asset.ModifedByUserId,
                ModifiedDateTime = asset.ModifiedDateTime,
                CreatedByUserId = asset.CreatedByUserId,
                CreatedDateTime = asset.CreatedDateTime
            };*/
           // var newAsset = await _assetRepository.AddAssetAsync(asset);
           // return new CommonResult<int>(newAsset.Payload, newAsset.ResultCode);
        //}

        public async Task<ICommonResult<int>> AddSoftwareAsync(AddSoftwareRequestModel asset)
        {
            /* var dbAsset = new Asset()
             {
                 Description = asset.Description,
                 Name = asset.Name,
                 LicenseCount = asset.LicenseCount,
                 CapabilityId = asset.CapabilityId,


                 ModifedByUserId = asset.ModifedByUserId,
                 ModifiedDateTime = asset.ModifiedDateTime,
                 CreatedByUserId = asset.CreatedByUserId,
                 CreatedDateTime = asset.CreatedDateTime
             };*/
            var newAsset = await _assetRepository.AddSoftwareAsync(asset);
            return new CommonResult<int>(newAsset.Payload, newAsset.ResultCode);
        }

        public async Task<ICommonResult<AddSoftwareResponseModel>> GetSoftwareByIdAsync(int softwareId)
        {
            /* var dbAsset = new Asset()
             {
                 Description = asset.Description,
                 Name = asset.Name,
                 LicenseCount = asset.LicenseCount,
                 CapabilityId = asset.CapabilityId,


                 ModifedByUserId = asset.ModifedByUserId,
                 ModifiedDateTime = asset.ModifiedDateTime,
                 CreatedByUserId = asset.CreatedByUserId,
                 CreatedDateTime = asset.CreatedDateTime
             };*/
            var software = await _assetRepository.GetSoftwareByIdAsync(softwareId);
            var foundSoftware = new AddSoftwareResponseModel()
            {
                Id = software.Payload.Id,
                Name = software.Payload.Name,
                Description = software.Payload.Description,
                CreatedDateTime = software.Payload.CreatedDateTime,
                LicenseCount = software.Payload.LicenseCount

            };
            return new CommonResult<AddSoftwareResponseModel>(foundSoftware, software.ResultCode);
        }

    }
}
