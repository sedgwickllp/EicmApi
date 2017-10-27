using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum LineOfBusinessType
    {
        [DisplayName("Firm")]
        [Active(true)]
        Firm = 1,

        [DisplayName("Legal")]
        [Active(true)]
        Legal = 2,

        [DisplayName("Finance")]
        [Active(true)]
        Finance = 3,
        
        [DisplayName("Marketing")]
        [Active(true)]
        FMarketing = 4,

        [DisplayName("HR")]
        [Active(true)]
        HR = 5,

        [DisplayName("IT")]
        [Active(true)]
        IT = 6,

        [DisplayName("OPS")]
        [Active(true)]
        OPS= 7,

        [DisplayName("Word Processing")]
        [Active(true)]
        WordProcessing = 8
    }
}