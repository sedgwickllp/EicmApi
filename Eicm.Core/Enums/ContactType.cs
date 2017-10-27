using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum ContactType
    {
        [DisplayName("Support")]
        [Active(true)]
        Support = 0,
        [DisplayName("Finance")]
        [Active(true)]
        Finance = 1
    }
}