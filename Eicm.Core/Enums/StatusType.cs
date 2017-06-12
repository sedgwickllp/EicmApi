using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum StatusType
    {
        [DisplayName("Open")]
        [Active(true)]
        Open = 1,

        [DisplayName("Closed")]
        [Active(true)]
        PendingFeedback = 2,

        [DisplayName("On Hold")]
        [Active(true)]
        OnHold = 3
    }
}