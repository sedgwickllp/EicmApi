using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Vendors;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class VendorContractBusinessLogic : IVendorContractBusinessLogic
    {
        private readonly IVendorContractRepository _vendorContractRepository;
        private readonly IVendorRepository  _vendorRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public VendorContractBusinessLogic(IVendorContractRepository vendorContractRepository, IVendorRepository vendorRepository)
        {
            _vendorContractRepository = vendorContractRepository;
            _vendorRepository = vendorRepository;
        }
        public async Task<ICommonResult<VendorContractModel>> GetContractsByVendorIdAsync(int id)
        {
            _logger.Info("Retrieving vendor id: " + id);
            var dbvendor = await _vendorRepository.GetVendorByIdAsync(id);
            var dbcontracts = await _vendorContractRepository.GetContractsByVendorIdAsync(id);
            if (dbvendor.ResultCode && dbvendor.Payload == null)
            {
                _logger.Info("No vendor returned for id: " + id);
                return new CommonResult<VendorContractModel>(null, dbvendor.ResultCode);
            }
            if (!dbvendor.ResultCode)
            {
                _logger.Info("getVendorByIdAsync returned failed from repo");
                return new CommonResult<VendorContractModel>(null, dbvendor.ResultCode, dbvendor.Message);
            }
            _logger.Info("Vendor retrieved");
            var vendor = new VendorContractModel()
            {
                VendorDetail = new VendorDetailModel(dbvendor.Payload),
                //vendor.VendorAccounts = dbvendor.Payload.VendorAccounts?.Select(x => new VendorAccountsModel(x.Account)).ToList();
                VendorContracts = dbcontracts.Payload.Select(x => new ContractDetailModel(x.Contract)).ToList()
            };
            return new CommonResult<VendorContractModel>(vendor, true); 
        }

        public async Task<ICommonResult<int>> AddContractToVendorAsync( int contractId, int vendorId, int userId)
        {
            var newVendorContract = await _vendorContractRepository.AddContractToVendorAsync(contractId, vendorId, userId);
            return new CommonResult<int>(newVendorContract.Payload, newVendorContract.ResultCode);
        }

        public async Task<ICommonResult<bool>> RemoveContractFromVendorAsync(int id)
        {
            var dbVendor = await _vendorContractRepository.RemoveContractFromVendorAsync(id);

            return new CommonResult<bool>(dbVendor.ResultCode);
        }
       
    }
}
