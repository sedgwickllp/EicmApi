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
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.Core.Models;
using Eicm.Core.Models.ResponseModels;
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

        public async Task<ICommonResult<GetContractAssetResponseModel>> GetContractAssetsAsync(int contractId)
        {
            try
            {
                var contractAssetList = await _coreDbContext.ContractAssets
                    .Where(ca => ca.ContractId == contractId)
                    .Include(ca => ca.Asset)
                    .OrderBy(c => c.CreatedDateTime)
                    .ToListAsync();

                if (contractAssetList.Count.Equals(0))
                {
                    return new CommonResult<GetContractAssetResponseModel>(null, ResultCode.Failure);

                }
                var contract = contractAssetList[0].Contract;
                var contractAssetResponse = new GetContractAssetResponseModel()
                {
                    Id = contract.Id,
                    CreatedByUserId = contract.CreatedByUserId,
                    CreatedDateTime = contract.CreatedDateTime,
                    ModifiedDateTime = contract.ModifiedDateTime,
                    ModifiedByUserId = contract.ModifedByUserId,
                    TermStartDate = contract.TermStartDate,
                    TermEndDate = contract.TermEndDate,
                    EarlyExitDate = contract.EarlyExitDate,
                    Terms = contract.Terms,
                    ContractStatus = ((ContractStatusType)contract.ContractStatus).GetEnumDisplayName(),
                    OverallStatus = ((ContractGlobalStatusType)contract.OverallStatus).GetEnumDisplayName(),
                    WorkflowStatus = ((DataStatusType)contract.WorkflowStatus).GetEnumDisplayName(),
                    LineOfBusiness = ((LineOfBusinessType)contract.LineOfBusiness).GetEnumDisplayName(),
                    PricingMethod = contract.PricingMethod != null ? ((PricingMethodType)contract.PricingMethod).GetEnumDisplayName() : "",
                    PricingAmount = contract.PricingAmount,
                    PriceBreaks = contract.PriceBreaks,
                    Cost = contract.Cost,
                    MonthlyBudget = contract.MonthlyBudget,
                    GeneralLedgerAccount = contract.GeneralLedgerAccount,
                    Location = (contract.Location != null) ? ((LocationType)contract.Location).GetEnumDisplayName() : ""
                };
                contractAssetResponse.SoftwareList = contractAssetList.Select(x => new AddSoftwareResponseModel()
                {
                    Id = x.Asset.Id,
                    Name = x.Asset.Name,
                    Version = x.Asset.Version,
                    Year = x.Asset.ModelYear,
                    Description = x.Asset.Description,
                    CapabilityType = x.Asset.CapabilityId,
                    LicenseCount = x.Asset.LicenseCount,
                    AvgDailyUsers = x.Asset.AvgDailyUsers,
                    UserRangeType = x.Asset.UserRangeId

                }).ToList();
                return new CommonResult<GetContractAssetResponseModel>(contractAssetResponse, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<GetContractAssetResponseModel>(null, ResultCode.Failure, ex.Message);
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
