using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Core;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("VendorAddresses", Schema = "Vendors")]
    public class VendorAddress : EntityBase
    {
        public int VendorId { get; set; }
        public int AddressId { get; set; }
        public int AddressType { get; set; }
        public virtual Address Address { get; set; }
        public virtual Vendor Vendor { get; set; }


    }
}
