using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("AccountContacts", Schema = "Vendors")]
    public class AccountContact : EntityBase
    {
        public int AccountId { get; set; }
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
