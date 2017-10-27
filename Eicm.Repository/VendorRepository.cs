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

namespace Eicm.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public VendorRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<Vendor>> GetVendorByIdAsync(int id)
        {
            try
            {
                var foundVendor = await _coreDbContext.Vendors.Include(v => v.VendorContracts).SingleAsync(v => v.Id == id);
                return new CommonResult<Vendor>(foundVendor, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<Vendor>(null, ResultCode.Failure, ex.Message);
            }
        }
        public async Task<ICommonResult<List<Vendor>>> GetVendorsAsync()
        {
            try
            {
                var vendors = await _coreDbContext.Vendors.Include(v => v.VendorContracts).OrderBy(c => c.Name).ToListAsync();
                return new CommonResult<List<Vendor>>(vendors, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<Vendor>>(null, ResultCode.Failure, ex.Message);
            }

        }

        public async Task<ICommonResult<int>> AddVendorAsync( string name, int userId)
        {
            try
            {
                var vendor = new Vendor
                {
                    Name = name,                   
                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };

                _coreDbContext.Vendors.Add(vendor);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(vendor.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<bool>> UpdateVendorAsync(int vendorId, string vendorName, bool isActive,  int userId)
        {
            try
            {
                var existingVendor = await _coreDbContext.Vendors.SingleAsync(t => t.Id == vendorId);
                {
                    existingVendor.Name = vendorName;
                    existingVendor.IsActive = isActive;

                    existingVendor.ModifedByUserId = userId;
                    existingVendor.ModifiedDateTime = DateTime.Now;
                }
                _coreDbContext.Vendors.AddOrUpdate(existingVendor);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
               
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<bool>> DeleteVendorAsync(int id)
        {
            try
            {
                var oldVendor = _coreDbContext.Vendors.First(v => v.Id == id);
                oldVendor.IsActive = false;
                _coreDbContext.Vendors.AddOrUpdate(oldVendor);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<bool>(ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<bool>(ResultCode.Failure, ResultCode.Failure, ex.Message);
            }

        }
        public async Task<ICommonResult<int>> AddContactAsync(string name, string phone, string email, int accountId, int contactType, int userId)
        {
            try
            {
                var contact = new Contact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,

                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };

                _coreDbContext.Contacts.Add(contact);
                await _coreDbContext.SaveChangesAsync();
                var accountContact = new AccountContact
                {
                    AccountId = accountId,
                    ContactId = contact.Id,
                    ContactTypeId = contactType,

                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };
                _coreDbContext.AccountContacts.Add(accountContact);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(contact.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<int>> AddAccountContactAsync( int accountId, int contactId, int contactType, int userId)
        {
            try
            {
               
                var accountContact = new AccountContact
                {
                    AccountId = accountId,
                    ContactId = contactId,
                    ContactTypeId = contactType,

                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };
                _coreDbContext.AccountContacts.Add(accountContact);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(accountContact.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<int>> AddContractAsync(Contract contract, int userId, int accountId)
        {
            try
            {

                var newContract = new Contract
                {
                    TermStartDate = contract.TermStartDate,
                    TermEndDate = contract.TermEndDate,
                    Terms = contract.Terms,
                    ExitConditions = contract.ExitConditions,
                    EarlyExitDate = contract.EarlyExitDate,
                    ContractStatus = contract.ContractStatus,
                    OverallStatus = contract.OverallStatus,
                    WorkflowStatus = contract.WorkflowStatus,
                    LineOfBusiness = contract.LineOfBusiness,
                    PricingMethod = contract.PricingMethod,
                    PricingAmount = contract.PricingAmount,
                    PriceBreaks = contract.PriceBreaks,
                    Cost = contract.Cost,
                    MonthlyBudget = contract.MonthlyBudget,
                    GeneralLedgerAccount = contract.GeneralLedgerAccount,
                    Location = contract.Location,
                    //Comments = contract.Comments,

                    IsActive = true,
                    CreatedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifedByUserId = userId,
                    ModifiedDateTime = DateTime.Now
                };
                _coreDbContext.Contracts.Add(newContract);

                var newAccountContract = new AccountContract
                {
                    AccountId = accountId,
                    ContractId = newContract.Id
                };
                _coreDbContext.AccountContracts.Add(newAccountContract);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(newContract.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }
    }
}
