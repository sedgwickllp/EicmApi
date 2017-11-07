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


            var contract = new ContractDTO()
            {
                ContractDetail = new ContractDetailModel(dbContract.Payload)
            };
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
     public async Task<ICommonResult<int>> AddContractAsync(ContractAddDTO contract)
     {
         
            var dbcontract = new Contract()
            {
                TermEndDate = contract.TermEndDate,
                TermStartDate = contract.TermStartDate,
                Terms = contract.Terms,
                EarlyExitDate = contract.EarlyExitDate,
                ExitConditions = contract.ExitConditions,
                ContractStatus = contract.ContractStatus,
                OverallStatus = contract.OverallStatus,
                WorkflowStatus = contract.WorkflowStatus,
                LineOfBusiness = contract.LineOfBusiness,
                PricingMethod = contract.PricingMethod,
                PricingAmount = contract.PricingAmount,
                PriceBreaks = contract.PricingBreaks,
                Cost = contract.Cost,
                MonthlyBudget = contract.MonthlyBudget,
                GeneralLedgerAccount = contract.GeneralLedgetAccount,
                Location = contract.Location,
                ModifedByUserId = contract.ModifedByUserId,
                ModifiedDateTime = contract.ModifiedDateTime,
                CreatedByUserId = contract.CreatedByUserId,
                CreatedDateTime = contract.CreatedDateTime
            };
            var newContract = await _contractRepository.AddContractAsync(dbcontract);
             return new CommonResult<int>(newContract.Payload, newContract.ResultCode);
         }

      
    }
}
