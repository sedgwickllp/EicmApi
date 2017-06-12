using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum CategoryType
    {
        [DisplayName("Antivirus Services")]
        [Active(true)]
        Antivirus = 1,

        [DisplayName("Conference Services")]
        [Active(true)]
        Conference = 2,

        [DisplayName("Consumer Technology")]
        [Active(true)]
        ConsumerTech = 3,

        [DisplayName("Core Applications")]
        [Active(true)]
        CoreApps = 4,

        [DisplayName("Equipment")]
        [Active(true)]
        Equipment = 5,

        [DisplayName("Local Office Technology")]
        [Active(true)]
        LocalOfficeTech = 6,

        [DisplayName("Messaging")]
        [Active(true)]
        Messaging = 7,

        [DisplayName("Network")]
        [Active(true)]
        Network = 8,

        [DisplayName("Non-Core Applications")]
        [Active(true)]
        NonCoreApps = 9,

        [DisplayName("Remote Access")]
        [Active(true)]
        RemoteAccess = 10,

        [DisplayName("Server Maintenance")]
        [Active(true)]
        ServerMaintenance = 11,

        [DisplayName("User Accounts")]
        [Active(true)]
        UserAccounts = 12

    }
}