using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum PriorityType
    {
        [DisplayName("Emergency")]
        [Active(true)]
        Emergency = 1,

        [DisplayName("High")]
        [Active(true)]
        High = 2,

        [DisplayName("Medium")]
        [Active(true)]
        Medium = 3,

        [DisplayName("Low")]
        [Active(true)]
        Low = 4,

        [DisplayName("iManage")]
        [Active(true)]
        IManage = 5,

        [DisplayName("MAC")]
        [Active(true)]
        MoveAddChange = 6
    }
}
