using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum DollarThresholdType
    {
        [DisplayName("A-$0-$10,000")]
        [Active(true)]
        A = 1,

        [DisplayName("B-$10,001-$25,000")]
        [Active(true)]
        B = 2,

        [DisplayName("C-25,001-$75,000")]
        [Active(true)]
        C = 3,

        [DisplayName("D-$75,001-$100,000")]
        [Active(true)]
        D = 4,

        [DisplayName("E-$100,001-$199,999")]
        [Active(true)]
        E = 5,

        [DisplayName("F-$200,000-$500,000")]
        [Active(true)]
        F = 6,

        [DisplayName("G-$500,001-$5,000,000")]
        [Active(true)]
        G = 7
    }
}