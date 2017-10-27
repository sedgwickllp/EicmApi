using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("ContractContacts", Schema = "Vendors")]
    public class ContractContact : EntityBase
    {
        public int ContractId { get; set; }
        public int? ContactId { get; set; }
        public int? EmployeeId { get; set; }
        public int ContactTypeId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
