using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("Contracts", Schema = "Vendors")]
    public class Contract : EntityBase
    {

        public DateTime? TermStartDate { get; set; }
        public DateTime? TermEndDate { get; set; }
        public string Terms { get; set; }
        
        public string ExitConditions { get; set; }
        public DateTime? EarlyExitDate { get; set; }
        
        public int ContractStatus { get; set; }
        public int OverallStatus { get; set; }
        public int WorkflowStatus { get; set; }
        public int LineOfBusiness { get; set; }
        public int? PricingMethod { get; set; }
        public decimal? PricingAmount { get; set; }
        public string PriceBreaks { get; set; }
        

        public decimal? Cost { get; set; }
        public decimal? MonthlyBudget { get; set; }
        public int GeneralLedgerAccount { get; set; }

        public int? Location { get; set; }
        public string AccountNumber { get; set; }
        public int? TempId { get; set; }
        //public virtual List<ContractComment> Comments { get; set; }

    }
}
