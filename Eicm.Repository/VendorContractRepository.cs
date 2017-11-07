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
    public class VendorContractRepository : IVendorContractRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public VendorContractRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<List<VendorContract>>> GetContractsByVendorIdAsync(int id)
        {
            
            try
            {
                var vendors = await _coreDbContext.VendorContracts.Where(v => v.VendorId == id).Include(v => v.Contract).ToListAsync();
                return new CommonResult<List<VendorContract>>(vendors, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<List<VendorContract>>(null, ResultCode.Failure, ex.Message);
            }
            
            
        }
        

        
        public async Task<ICommonResult<int>> AddContractToVendorAsync(int contractId,  int vendorId, int userId)
        {
            try { 
               ;

                var newVendorContract = new VendorContract
                {
                    VendorId = vendorId,
                    ContractId = contractId,
                    //CreatedByUserId = userId,
                    //ModifedByUserId = userId,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now,
                    IsActive = true
                };
                _coreDbContext.VendorContracts.Add(newVendorContract);
                await _coreDbContext.SaveChangesAsync();
                return new CommonResult<int>(contractId, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<bool>> RemoveContractFromVendorAsync(int vendorContractId)
        {
            try
            {
                var oldContract = _coreDbContext.VendorContracts.First(vc => vc.Id == vendorContractId);
                oldContract.IsActive = false;
                _coreDbContext.VendorContracts.AddOrUpdate(oldContract);
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
