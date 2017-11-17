using Eicm.Core.Extensions;

using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Assets;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eicm.Core.Models.RequestModels;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public AssetRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        
        
       /* public async Task<ICommonResult<int>> AddAssetAsync(AssetModel asset)
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
            try
            {
                _coreDbContext.Assets.Add(dbAsset);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(asset.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }
        */

        public async Task<ICommonResult<int>> AddSoftwareAsync(AddSoftwareRequestModel asset)
        {
            var dbAsset = new Asset()
            {
                Description = asset.Description,
                Name = asset.Name,
                LicenseCount = asset.LicenseCount,
                CapabilityId = asset.CapabilityType,
                ModelYear = asset.Year,
                AvgDailyUsers = asset.AvgDailyUsers,
                UserRangeId = asset.UserRangeType,

                ModifedByUserId = asset.UserId,
                ModifiedDateTime = DateTime.Now,
                CreatedByUserId = asset.UserId,
                CreatedDateTime = DateTime.Now
            };
            try
            {
                _coreDbContext.Assets.Add(dbAsset);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(dbAsset.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<Asset>> GetSoftwareByIdAsync(int softwareId)
        {
            try
            {
                var software = await _coreDbContext.Assets.SingleAsync(t => t.Id == softwareId);
                   
                   
                return new CommonResult<Asset>(software, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<Asset>(null, ResultCode.Failure, ex.Message);
            }
        }


    }
}
