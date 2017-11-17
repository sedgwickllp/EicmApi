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
using AutoMapper;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;
using Eicm.DataLayer.Entities.Assets;

namespace Eicm.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        //private readonly IMapper _mapper;
        public ContractRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
            //_mapper = mapper;
        }
        public async Task<ICommonResult<GetContractResponseModel>> GetContractByIdAsync(int id)
        {
            try
            {
                var contract = await _coreDbContext.Contracts.SingleAsync(c => c.Id == id);
                var returnContract = Mapper.Map<GetContractResponseModel>(contract); /*new GetContractResponseModel()
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
                    PriceBreaks = contract.PriceBreaks,
                    Cost = contract.Cost,
                    MonthlyBudget = contract.MonthlyBudget,
                    GeneralLedgerAccount = contract.GeneralLedgerAccount,
                    Location = contract.Location,
                    ModifiedByUserId = contract.ModifedByUserId,
                    ModifiedDateTime = contract.ModifiedDateTime,
                    CreatedByUserId = contract.CreatedByUserId,
                    CreatedDateTime = contract.CreatedDateTime
                };*/
                return new CommonResult<GetContractResponseModel>(returnContract, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<GetContractResponseModel>(null, ResultCode.Failure, ex.Message);
            }
        }
       

       
        public async Task<ICommonResult<int>> AddContractAsync(AddContractRequestModel contract)
        {
            try
            {
                var dbcontract = Mapper.Map<Contract>(contract);/* new Contract()
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
                    PriceBreaks = contract.PriceBreaks,
                    Cost = contract.Cost,
                    MonthlyBudget = contract.MonthlyBudget,
                    GeneralLedgerAccount = contract.GeneralLedgerAccount,
                    Location = contract.Location,
                    ModifedByUserId = contract.UserId,
                    ModifiedDateTime = DateTime.Now,
                    CreatedByUserId = contract.UserId,
                    CreatedDateTime = DateTime.Now
                };*/
                _coreDbContext.Contracts.Add(dbcontract);
                await _coreDbContext.SaveChangesAsync();

                
                return new CommonResult<int>(dbcontract.Id, ResultCode.Success);
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
