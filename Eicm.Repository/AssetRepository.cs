using Eicm.Core.Extensions;
using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Vendors;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Assets;

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
        
        
        public async Task<ICommonResult<int>> AddAssetAsync(Asset asset)
        {
            try
            {
                _coreDbContext.Assets.Add(asset);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(asset.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }
       
    

        public async Task<ICommonResult<int>> AddAssetToContractAsync(int assetId, int contractId)
        {
            try
            {
    
                var newContractAsset = new ContractAsset
                {
                    ContractId = contractId,
                    AssetId = assetId
                };
            _coreDbContext.ContractAssets.Add(newContractAsset);
            await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(assetId, ResultCode.Success);
            }
            catch (Exception ex)
            {
            _log.Error(ex.GetBaseException());
            return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

    }
}
