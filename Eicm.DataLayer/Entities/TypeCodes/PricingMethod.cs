using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.TypeCodes
{
    [Table("PricingMethods", Schema = "TypeCodes")]
    public class PricingMethod : EnumEntityBase
    {
    }
}
