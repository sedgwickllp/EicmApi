using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum ContractGlobalStatusType
    {
        [DisplayName("1-Active")]
        [Active(true)]
        Active = 1,

        [DisplayName("2-Closed/Closing")]
        [Active(true)]
        Closed = 2,

        [DisplayName("3-No Contract - Preferred Vendor")]
        [Active(true)]
        NoContract = 3
    }
}