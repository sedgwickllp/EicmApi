using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Core;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("ContactAddresses", Schema = "Vendors")]
    public class ContactAddress : EntityBase
    {
        public int ContactId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
