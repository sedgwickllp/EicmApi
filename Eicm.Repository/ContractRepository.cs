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
    public class ContractRepository : IContractRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public ContractRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<Contract>> GetContractByIdAsync(int id)
        {
            try
            {
                var foundContract = await _coreDbContext.Contracts.SingleAsync(c => c.Id == id);
                return new CommonResult<Contract>(foundContract, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<Contract>(null, ResultCode.Failure, ex.Message);
            }
        }
       

       
        public async Task<ICommonResult<int>> AddContractAsync(Contract contract)
        {
            try { 
                _coreDbContext.Contracts.Add(contract);
                await _coreDbContext.SaveChangesAsync();

                
                return new CommonResult<int>(contract.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        public async Task<ICommonResult<bool>> DeleteContractAsync(int id)
        {
            try
            {
                var oldContract = _coreDbContext.Contracts.First(c => c.Id == id);
                oldContract.IsActive = false;
                _coreDbContext.Contracts.AddOrUpdate(oldContract);
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
