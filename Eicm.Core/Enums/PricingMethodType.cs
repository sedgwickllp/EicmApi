using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum PricingMethodType
    {
        [DisplayName("1-Usage/Licenses")]
        [Active(true)]
        Usage = 1,

        [DisplayName("2-By Project")]
        [Active(true)]
        Project = 2,

        [DisplayName("3-By Unit")]
        [Active(true)]
        Unit = 3
    }
}