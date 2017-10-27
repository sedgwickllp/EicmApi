using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum ProductDispositionType
    {
        [DisplayName("A - Product the firm will renew")]
        [Active(true)]
        Renew = 1,

        [DisplayName("B - Duplicate product others will migrate to")]
        [Active(true)]
        MigrateTo = 2,

        [DisplayName("C - Duplicate product that will migrat to another")]
        [Active(true)]
        MigrateFrom = 3,

        [DisplayName("D - Contract ends in current year and will not renew")]
        [Active(true)]
        NoRenew = 4,

        [DisplayName("E - Contract ends in future year and will not renew")]
        [Active(true)]
        NoFutureRenew = 5,

        [DisplayName("F - TBD")]
        [Active(true)]
        TDB = 6
    }
}