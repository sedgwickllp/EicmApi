using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("Accounts", Schema = "Vendors")]
    public class Account : EntityBase
    {
        public string AccountNumber { get; set; }
        public virtual List<AccountContract> AccountContracts { get; set; }
        public virtual List<AccountContact> AccountContacts { get; set; }
    }
}
