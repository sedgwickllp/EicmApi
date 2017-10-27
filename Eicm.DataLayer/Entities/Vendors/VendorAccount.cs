using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("VendorAccounts", Schema = "Vendors")]
    public class VendorAccount : EntityBase
    {
        public int VendorId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Vendor Vendor { get; set; }
    }

}
