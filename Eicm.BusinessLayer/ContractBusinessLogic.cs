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
    public class ContractBusinessLogic : IContractBusinessLogic
    {
        private readonly IContractRepository _contractRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractBusinessLogic(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public async Task<ICommonResult<ContractDTO>> GetContractByIdAsync(int id)
        {
            _logger.Info("Retrieving contract with id: " + id);
            var dbContract = await _contractRepository.GetContractByIdAsync(id);

            if (dbContract.ResultCode && dbContract.Payload == null)
            {
                _logger.Info("No contract returned for id: " + id);
                return new CommonResult<ContractDTO>(null, dbContract.ResultCode);
            }
            if (!dbContract.ResultCode)
            {
                _logger.Info("getContractByIdAsync returned failed from repo");
                return new CommonResult<ContractDTO>(null, dbContract.ResultCode, dbContract.Message);
            }
            _logger.Info("Contract retrieved");
            
            
            var contract = new ContractDTO();
            contract.ContractDetail = new ContractDetailModel(dbContract.Payload);
            
            return new CommonResult<ContractDTO>(contract, true); 
        }

       
       

       /* public async Task<ICommonResult<bool>> UpdateContractAsync(ContractModel contract, int userId)
        {
            var existingContract = await _contractRepository.GetContractByIdAsync(contract.ContractId);
            existingContract.Payload.ContractStatus = contract.ContractStatus;
           // return new CommonResult<bool>(updatedVendor.Payload, updatedVendor.ResultCode);
        }*/

       /* public async Task<ICommonResult<bool>> DeleteContractByIdAsync(int id)
        {
            var dbVendor = await _contractRepository.DeleteContractAsync(id);

            return new CommonResult<bool>(dbVendor.ResultCode);
        }*/
     public async Task<ICommonResult<int>> AddContractAsync(VendorContractAddDTO vendorContract)
     {
         var contract = vendorContract.Contract;
             var dbcontract = new Contract();
             dbcontract.TermEndDate = contract.TermEndDate;
             dbcontract.TermStartDate = contract.TermStartDate;
             dbcontract.Terms = contract.Terms;
             dbcontract.EarlyExitDate = contract.EarlyExitDate;
             dbcontract.ExitConditions = contract.ExitConditions;
             dbcontract.ContractStatus = contract.ContractStatus;
             dbcontract.OverallStatus = contract.OverallStatus;
             dbcontract.WorkflowStatus = contract.WorkflowStatus;
             dbcontract.LineOfBusiness = contract.LineOfBusiness;
             dbcontract.PricingMethod = contract.PricingMethod;
             dbcontract.PricingAmount = contract.PricingAmount;
             dbcontract.PriceBreaks = contract.PricingBreaks;
             dbcontract.Cost = contract.Cost;
             dbcontract.MonthlyBudget = contract.MonthlyBudget;
             dbcontract.GeneralLedgerAccount = contract.GeneralLedgetAccount;
             dbcontract.Location = contract.Location;
             dbcontract.ModifedByUserId = contract.ModifedByUserId;
             dbcontract.ModifiedDateTime = contract.ModifiedDateTime;
             dbcontract.CreatedByUserId = contract.CreatedByUserId;
             dbcontract.CreatedDateTime = contract.CreatedDateTime;
             var newContract = await _contractRepository.AddContractAsync(dbcontract, vendorContract.VendorId);
             return new CommonResult<int>(newContract.Payload, newContract.ResultCode);
         }

        /* public async Task<ICommonResult<int>> AddContractAssetAsync(ContractAssetModel contractAsset)
         {

         }*/
        public async Task<ICommonResult<int>> AddAssetAsync(AssetModel asset, int contractId)
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
            var newAsset = await _contractRepository.AddAssetAsync(dbAsset, contractId);
            return new CommonResult<int>(newAsset.Payload, newAsset.ResultCode);
        }
    }
}
