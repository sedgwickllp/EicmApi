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
    public class ContractAssetRepository : IContractAssetRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public ContractAssetRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }

        public async Task<ICommonResult<List<ContractAsset>>> GetContractAssetsAsync(int contractId)
        {
            try
            {
                var contractAssetList = await _coreDbContext.ContractAssets
                    .Where(ca => ca.ContractId == contractId)
                    .Include(ca => ca.Asset)
                    .OrderBy(c => c.CreatedDateTime)
                    .ToListAsync();
                return new CommonResult<List<ContractAsset>>(contractAssetList, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<ContractAsset>>(null, ResultCode.Failure, ex.Message);
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

        public async Task<ICommonResult<bool>> RemoveAssetFromContractAsync(int contractId, int assetId)
        {
            try
            {
                var oldContractAsset = _coreDbContext.ContractAssets.First(t1 => t1.ContractId == contractId && t1.AssetId == assetId);
                oldContractAsset.IsActive = false;
                _coreDbContext.ContractAssets.AddOrUpdate(oldContractAsset);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }

        }

    }
}
