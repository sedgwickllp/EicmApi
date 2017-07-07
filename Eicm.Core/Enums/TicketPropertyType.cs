using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum TicketPropertyType
    {
        [DisplayName("Category")]
        [Active(true)]
        CategoryId = 1,

        [DisplayName("Cause")]
        [Active(true)]
        CauseId = 2,

        [DisplayName("Origin")]
        [Active(true)]
        OriginId = 3,

        [DisplayName("Priority")]
        [Active(true)]
        PriorityId = 4,

        [DisplayName("Status")]
        [Active(true)]
        StatusId = 5,

        [DisplayName("SubCategory")]
        [Active(true)]
        SubCategoryId = 6,

        [DisplayName("Summary")]
        [Active(true)]
        Summary = 7,

        [DisplayName("Owner")]
        [Active(true)]
        OwnerId = 8,

        [DisplayName("Requester")]
        [Active(true)]
        RequesterId = 9,

        [DisplayName("IsDeleted")]
        [Active(true)]
        IsDeleted = 10,

        [DisplayName("IsConfidential")]
        [Active(true)]
        IsConfidential = 11
    }
}