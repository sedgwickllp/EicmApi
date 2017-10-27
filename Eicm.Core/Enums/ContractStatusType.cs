using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum ContractStatusType
    {
        [DisplayName("1-Active")]
        [Active(true)]
        Active = 1,

        [DisplayName("2-Proposed")]
        [Active(true)]
        Proposed = 2,

        [DisplayName("3-Re-Negotiating")]
        [Active(true)]
        Renegotiating = 3,

        [DisplayName("4-Closed (Engagement Completed)")]
        [Active(true)]
        ClosedCompleted = 4,

        [DisplayName("5-Vendor signed but not active")]
        [Active(true)]
        SignedInactive = 5,

        [DisplayName("6-Closed (Engagement Terminated)")]
        [Active(true)]
        ClosedTerminated = 6,

        [DisplayName("7-Closing in current year (do not renew)")]
        [Active(true)]
        DoNotRenewCY = 7,

        [DisplayName("8-Closing in future year (do not renew)")]
        [Active(true)]
        DoNotRenewFY = 8,

        [DisplayName("9-Will renew in current year")]
        [Active(true)]
        RenewCY = 9,

        [DisplayName("10-Will renew in future year")]
        [Active(true)]
        RenewFY = 10,

        [DisplayName("11-No Contract - Use as needed")]
        [Active(true)]
        NoContract = 11,

        [DisplayName("12-Telecom - On Contract")]
        [Active(true)]
        TelecomContract = 12,

        [DisplayName("13-Telecom - Month to Month")]
        [Active(true)]
        TelecomMTM = 13,

        [DisplayName("14-Needs more research")]
        [Active(true)]
        ResearchNeeded = 14,

        [DisplayName("15-Preferred Vendor")]
        [Active(true)]
        PreferredVendor = 15
    }
}