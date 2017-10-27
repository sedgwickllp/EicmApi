using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum VendorType
    {
        [DisplayName("1-Software")]
        [Active(true)]
        Software = 1,

        [DisplayName("1a-Software Maintenance")]
        [Active(true)]
        SoftwareMaintenance = 2,

        [DisplayName("2-Hardware")]
        [Active(true)]
        Hardware = 3,

        [DisplayName("2a-Hardware Maintenance")]
        [Active(true)]
        HardwareMaintenance = 4,

        [DisplayName("3-Consulting")]
        [Active(true)]
        Consulting = 5,

        [DisplayName("4-Contracting")]
        [Active(true)]
        Contracting = 6,

        [DisplayName("5-Telecom")]
        [Active(true)]
        Telecom = 7,

        [DisplayName("6-Leasing")]
        [Active(true)]
        Leasing = 8
    }
}
