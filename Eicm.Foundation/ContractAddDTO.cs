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
    public class ContractAddDTO
    {

        public int ContractId { get; set; }
        public int AccountId { get; set; }
        public DateTime? TermStartDate { get; set; }
        public DateTime? TermEndDate { get; set; }
        public DateTime? EarlyExitDate { get; set; }
        public string ExitConditions { get; set; }
        public string Terms { get; set; }
        public int ContractStatus { get; set; }
        public int OverallStatus { get; set; }
        public int WorkflowStatus { get; set; }
        public int LineOfBusiness { get; set; }
        public int PricingMethod { get; set; }
        public decimal? PricingAmount { get; set; }
        public string PricingBreaks { get; set; }
        public decimal? Cost { get; set; }
        public decimal? MonthlyBudget { get; set; }
        public int GeneralLedgetAccount { get; set; }
        public int Location { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }
    }

    public class VendorContractAddDTO
    {
        public ContractAddDTO Contract { get; set; }
        public int VendorId { get; set; }
    }
}
