using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum OriginType
    {
        [DisplayName("Email")]
        [Active(true)]
        Email = 1,

        [DisplayName("Phone")]
        [Active(true)]
        Phone = 2,

        [DisplayName("In-Person")]
        [Active(true)]
        InPerson = 3
    }
}