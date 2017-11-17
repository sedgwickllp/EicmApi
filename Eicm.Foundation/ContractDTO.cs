using Eicm.DataLayer.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.BusinessLogic.DataObjects
{
    public class ContractDTO
    {
        public ContractDetailModel ContractDetail { get; set; }
        public List<AssetModel> Assets { get; set; }
    }

    public class ContractDetailModel
    {
        public int ContractId { get; set; }
        public DateTime? TermStartDate { get; set; }
        public DateTime? TermEndDate { get; set; }
        public DateTime? EarlyExitDate { get; set; }
        public string ExitConditions { get; set; }
        public string Terms { get; set; }
        public string ContractStatus { get; set; }
        public string OverallStatus { get; set; }
        public string WorkflowStatus { get; set; }
        public string LineOfBusiness { get; set; }
        public string PricingMethod { get; set; }
        public decimal? PricingAmount { get; set; }
        public string PricingBreaks { get; set; }
        public decimal? Cost { get; set; }
        public decimal? MonthlyBudget { get; set; }
        public int GeneralLedgetAccount { get; set; }
        public string Location { get; set; }

        public ContractDetailModel(Contract contract)
        {
            ContractId = contract.Id;
            TermStartDate = contract.TermStartDate;
            TermEndDate = contract.TermEndDate;
            EarlyExitDate = contract.EarlyExitDate;
            ExitConditions = contract.ExitConditions;
            Terms = contract.Terms;
            ContractStatus = ((ContractStatusType)contract.ContractStatus).GetEnumDisplayName();
            OverallStatus = ((ContractGlobalStatusType)contract.OverallStatus).GetEnumDisplayName();
            WorkflowStatus = ((DataStatusType)contract.WorkflowStatus).GetEnumDisplayName();
            LineOfBusiness = ((LineOfBusinessType)contract.LineOfBusiness).GetEnumDisplayName();
            PricingMethod = ((PricingMethodType)contract.PricingMethod).GetEnumDisplayName();
            PricingAmount = contract.PricingAmount;
            PricingBreaks = contract.PriceBreaks;
            Cost = contract.Cost;
            MonthlyBudget = contract.MonthlyBudget;
            GeneralLedgetAccount = contract.GeneralLedgerAccount;
        }
    }
}
