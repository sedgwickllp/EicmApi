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
    public class ContractBusinessLogic : IContractBusinessLogic
    {
        private readonly IContractRepository _contractRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractBusinessLogic(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public async Task<ICommonResult<GetContractResponseModel>> GetContractByIdAsync(int id)
        {
            _logger.Info("Retrieving contract with id: " + id);
            var dbContract = await _contractRepository.GetContractByIdAsync(id);

            if (dbContract.ResultCode && dbContract.Payload == null)
            {
                _logger.Info("No contract returned for id: " + id);
                return new CommonResult<GetContractResponseModel>(null, dbContract.ResultCode);
            }
            if (!dbContract.ResultCode)
            {
                _logger.Info("getContractByIdAsync returned failed from repo");
                return new CommonResult<GetContractResponseModel>(null, dbContract.ResultCode, dbContract.Message);
            }
            _logger.Info("Contract retrieved");


           
            return dbContract; 
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
         public async Task<ICommonResult<int>> AddContractAsync(AddContractRequestModel contract)
         {
    
            var newContract = await _contractRepository.AddContractAsync(contract);
             return new CommonResult<int>(newContract.Payload, newContract.ResultCode);
         }

      
    }
}
