using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum LocationType
    {
        [DisplayName("Austin")]
        [Active(true)]
        Austin = 1,

        [DisplayName("Bermuda")]
        [Active(true)]
        Bermuda = 2,

        [DisplayName("Chicago")]
        [Active(true)]
        Chicago = 3,

        [DisplayName("Dallas")]
        [Active(true)]
        Dallas = 4,

        [DisplayName("Houston")]
        [Active(true)]
        Houston = 5,

        [DisplayName("Kansas City")]
        [Active(true)]
        KansasCity = 0,

        [DisplayName("London")]
        [Active(true)]
        London = 6,

        [DisplayName("Los Angeles")]
        [Active(true)]
        LosAngeles = 7,

        [DisplayName("Miami")]
        [Active(true)]
        Miami = 8,

        [DisplayName("New York")]
        [Active(true)]
        NewYork = 9,

        [DisplayName("Orange County")]
        [Active(true)]
        OrangeCounty = 10,

        [DisplayName("San Fransisco")]
        [Active(true)]
        SanFransisco = 11,

        [DisplayName("Seattle")]
        [Active(true)]
        Seattle = 12,

        [DisplayName("Washington DC")]
        [Active(true)]
        WashingtonDC = 13,

        [DisplayName("Las Vegas")]
        [Active(true)]
        LasVegas = 14

    }
}