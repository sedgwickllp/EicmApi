using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("Vendors", Schema = "Vendors")]
    public class Vendor : EntityBase
    {
        public string Name { get; set; }

        public virtual List<VendorContract> VendorContracts { get; set; }
        public virtual List<VendorContact> VendorContacts { get; set; }
    }
}
