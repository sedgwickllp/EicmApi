using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum LicenseType
    {
        [DisplayName("None")]
        [Active(true)]
        None = 0,

        [DisplayName("Concurrent")]
        [Active(true)]
        Concurrent = 1,

        [DisplayName("Individual")]
        [Active(true)]
        Individual = 2,

        [DisplayName("Admin")]
        [Active(true)]
        Admin = 3,

        [DisplayName("Expert")]
        [Active(true)]
        Expert = 4
    }
}