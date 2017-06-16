using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum ActivityType
    {
        [DisplayName("Created")]
        [Active(true)]
        Created = 1,

        [DisplayName("Updated")]
        [Active(true)]
        Updated = 2,

        [DisplayName("Closed")]
        [Active(true)]
        Closed = 3,

        [DisplayName("Comment Added")]
        [Active(true)]
        CommentAdded = 4
    }
}