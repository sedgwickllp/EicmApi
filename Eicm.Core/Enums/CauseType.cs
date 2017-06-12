using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum CauseType
    {
        [DisplayName("Admin")]
        [Active(true)]
        Admin = 1,

        [DisplayName("Change Request")]
        [Active(true)]
        Change = 2,

        [DisplayName("Break/Fix")]
        [Active(true)]
        BreakFix = 3

    }
}
