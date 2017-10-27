using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("AccountContracts", Schema = "Vendors")]
    public class AccountContract : EntityBase
    {
        public int AccountId { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
