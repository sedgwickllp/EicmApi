using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("VendorContracts", Schema = "Vendors")]
    public class VendorContract : EntityBase
    {
        public int VendorId { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
