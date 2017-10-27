using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Core
{
    [Table("AddressTypes", Schema = "Core")]
    public class AddressType : EntityBase
    {
        public string Name { get; set; }
    }
}
