using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("ContractComments", Schema = "Vendors")]
    public class ContractComment : EntityBase
    {
        public int ContractId { get; set; }
        public string Comment { get; set; }
        
    }
}
