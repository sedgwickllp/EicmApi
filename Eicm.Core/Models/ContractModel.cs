using System;

namespace Eicm.Core.Models
{
    public class ContractModel
    {
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
        public string PriceBreaks { get; set; }
        public decimal? Cost { get; set; }
        public decimal? MonthlyBudget { get; set; }
        public int GeneralLedgerAccount { get; set; }
        public string Location { get; set; }
    }

   
}
