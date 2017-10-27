using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class ContractAssetBusinessLogic : IContractAssetBusinessLogic
    {
        private readonly IContractAssetRepository _contractAssetRepository;
        private readonly IContractBusinessLogic _contractBusinessLogic;
        private readonly IAssetBusinessLogic _assetBusinessLogic;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractAssetBusinessLogic(IContractAssetRepository contractAssetRepository, IContractBusinessLogic contractBusinessLogic, IAssetBusinessLogic assetBusinessLogic)
        {
            _contractAssetRepository = contractAssetRepository;
            _contractBusinessLogic = contractBusinessLogic;
            _assetBusinessLogic = assetBusinessLogic;
        }
        
       
        public async Task<ICommonResult<int>> AddAssetToContractAsync(AssetModel asset, int contractId)
        {
            var newAsset = await _assetBusinessLogic.AddAssetAsync(asset);
            var newContractAsset = await _contractAssetRepository.AddAssetToContractAsync(newAsset.Payload, contractId);
            return new CommonResult<int>(newAsset.Payload, newContractAsset.ResultCode);
        }

        public async Task<ICommonResult<ContractDTO>> GetContractAssetsAsync(int contractId)
        {
            _logger.Info("Retrieving assets for contract with id: " + contractId);
            var contract = await _contractBusinessLogic.GetContractByIdAsync(contractId);
            var dbassets = await _contractAssetRepository.GetContractAssetsAsync(contractId);

            if (dbassets.ResultCode && dbassets.Payload == null)
            {
                _logger.Info("No asset returned for id: " + contractId);
                return new CommonResult<ContractDTO>(null, dbassets.ResultCode);
            }
            if (!dbassets.ResultCode)
            {
                _logger.Info("getTicketByIdAsync returned failed from repo");
                return new CommonResult<ContractDTO>(null, dbassets.ResultCode, dbassets.Message);
            }
            _logger.Info("Ticket retrieved");
            
            contract.Payload.Assets = dbassets.Payload.Select(x => new AssetModel(x.Asset)).ToList(); ;
            return new CommonResult<ContractDTO>(contract.Payload, dbassets.ResultCode); ;
        }

        public async Task<ICommonResult<bool>> RemoveAssetFromContractAsync(int contractId, int assetId)
        {
            var dbresult = await _contractAssetRepository.RemoveAssetFromContractAsync(contractId, assetId);

            return new CommonResult<bool>(dbresult.ResultCode);
        }
    }
}
