using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum DataStatusType
    {
        [DisplayName("1-Pending additional information")]
        [Active(true)]
        PendingAdditionalInformation = 1,

        [DisplayName("2-Needs Director Review Sustainment")]
        [Active(true)]
        NeedsDirectorReviewSustainment = 2,

        [DisplayName("3-Needs Director Review Applications")]
        [Active(true)]
        NeedsDirectorReviewApplications = 3,

        [DisplayName("4-Needs Director Review InfoSec")]
        [Active(true)]
        NeedsDirectorReviewInfoSec = 4,

        [DisplayName("5-Needs LOB Approval")]
        [Active(true)]
        NeedsLOBApproval = 5,

        [DisplayName("6-Negotiating With Vendor")]
        [Active(true)]
        NegotiatingWithVendor = 6,

        [DisplayName("7-Prepping For CIO Signature")]
        [Active(true)]
        PreppingForCIOSignature = 7,

        [DisplayName("8-Waiting CIO Signature")]
        [Active(true)]
        WaitingCIOSignature = 8,

        [DisplayName("9-Completed")]
        [Active(true)]
        Completed = 9,
    }
}