using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Vendors;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class VendorBusinessLogic : IVendorBusinessLogic
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public VendorBusinessLogic(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<ICommonResult<VendorDTO>> GetVendorByIdAsync(int id)
        {
            _logger.Info("Retrieving vendor id: " + id);
            var dbvendor = await _vendorRepository.GetVendorByIdAsync(id);

            if (dbvendor.ResultCode && dbvendor.Payload == null)
            {
                _logger.Info("No vendor returned for id: " + id);
                return new CommonResult<VendorDTO>(null, dbvendor.ResultCode);
            }
            if (!dbvendor.ResultCode)
            {
                _logger.Info("getVendorByIdAsync returned failed from repo");
                return new CommonResult<VendorDTO>(null, dbvendor.ResultCode, dbvendor.Message);
            }
            _logger.Info("Vendor retrieved");
            var vendor = new VendorDTO()
            {
                VendorDetail = new VendorDetailModel(dbvendor.Payload)
            };
            //vendor.VendorAccounts = dbvendor.Payload.VendorAccounts?.Select(x => new VendorAccountsModel(x.Account)).ToList();

            return new CommonResult<VendorDTO>(vendor, true); 
        }

        public async Task<ICommonResult<List<VendorDetailModel>>> GetVendorsAsync()
        {
            _logger.Info("Retrieving all vendors");
            var dbvendorList = await _vendorRepository.GetVendorsAsync();

            if (dbvendorList.ResultCode)
            {
                var vendorList = dbvendorList.Payload.Select(vendor => new VendorDetailModel(vendor)).ToList();
                return new CommonResult<List<VendorDetailModel>>(vendorList, dbvendorList.ResultCode);
            }

            return new CommonResult<List<VendorDetailModel>>(null, dbvendorList.ResultCode, dbvendorList.Message);
        }

        public async Task<ICommonResult<int>> AddVendorAsync(string name, int userId)
        {
            var vendor = await _vendorRepository.AddVendorAsync(name, userId);
            return new CommonResult<int>(vendor.Payload, vendor.ResultCode);
        }

        public async Task<ICommonResult<bool>> UpdateVendorAsync(VendorUpdateModel vendor, int userId)
        {
            var updatedVendor = await _vendorRepository.UpdateVendorAsync(vendor.VendorId, vendor.Name, vendor.IsActive, userId);
            return new CommonResult<bool>(updatedVendor.Payload, updatedVendor.ResultCode);
        }

        public async Task<ICommonResult<bool>> DeleteVendorByIdAsync(int id)
        {
            var dbVendor = await _vendorRepository.DeleteVendorAsync(id);

            return new CommonResult<bool>(dbVendor.ResultCode);
        }
        /* public async Task<ICommonResult<int>> AddContractAsync(ContractAddModel contract, int userId, int accountId)
         {
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
             dbcontract.PriceBreaks = contract.PriceBreaks;
             dbcontract.YearlyBudget = contract.YearlyBudget;
             dbcontract.MonthlyBudget = contract.MonthlyBudget;
             dbcontract.GeneralLedgerAccount = contract.GeneralLedgetAccount;
             dbcontract.Location = contract.Location;
             dbcontract.Comments = contract.ContractComments;

             var newContract = await _vendorRepository.AddContractAsync(dbcontract, userId, accountId);
             return new CommonResult<int>(newContract.Payload, newContract.ResultCode);
         }*/
    }
}
