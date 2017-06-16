using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum TicketPropertyType
    {
        [DisplayName("Category")]
        [Active(true)]
        Category = 1,

        [DisplayName("Cause")]
        [Active(true)]
        Cause = 2,

        [DisplayName("Origin")]
        [Active(true)]
        Origin = 3,

        [DisplayName("Priority")]
        [Active(true)]
        Priority = 4,

        [DisplayName("Status")]
        [Active(true)]
        Status = 5,

        [DisplayName("SubCategory")]
        [Active(true)]
        SubCategory = 6,

        [DisplayName("Summary")]
        [Active(true)]
        Summary = 7,

        [DisplayName("Owner")]
        [Active(true)]
        Owner = 8,

        [DisplayName("Requester")]
        [Active(true)]
        Requester = 9,

        [DisplayName("IsDeleted")]
        [Active(true)]
        IsDeleted = 10
    }
}