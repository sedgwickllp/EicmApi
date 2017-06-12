using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum SubCategoryType
    {
        [DisplayName("Virus/Malware")]
        [Active(true)]
        [ParentId(1)]
        VirusMalware = 1,

        [DisplayName("Symantec Endpoint")]
        [Active(true)]
        [ParentId(1)]
        Symantec = 2,

        [DisplayName("Video Setup")]
        [Active(true)]
        [ParentId(2)]
        VideoSetup = 3,

        [DisplayName("Equipment Setup")]
        [Active(true)]
        [ParentId(2)]
        EquipmentSetup = 4,

        [DisplayName("iOS")]
        [Active(true)]
        [ParentId(3)]
        iOS = 5,

        [DisplayName("Android")]
        [Active(true)]
        [ParentId(3)]
        Android = 6,

        [DisplayName("iManage")]
        [Active(true)]
        [ParentId(4)]
        IManage = 7,

        [DisplayName("Outlook")]
        [Active(true)]
        [ParentId(4)]
        Outlook = 8,

        [DisplayName("Broadband Card")]
        [Active(true)]
        [ParentId(5)]
        BroadbandCard = 9,

        [DisplayName("LN Flat")]
        [Active(true)]
        [ParentId(6)]
        LnFlat = 10,

        [DisplayName("Distribution List Creation")]
        [Active(true)]
        [ParentId(7)]
        DistListCreation = 11,

        [DisplayName("Distribution List Modifiction")]
        [Active(true)]
        [ParentId(7)]
        DistListModification = 12,

        [DisplayName("Connectivity")]
        [Active(true)]
        [ParentId(8)]
        Connectivity = 13,

        [DisplayName("Sedgwick Office WiFi")]
        [Active(true)]
        [ParentId(8)]
        OfficeWiFi = 14,

        [DisplayName("BigHand")]
        [Active(true)]
        [ParentId(9)]
        BigHand = 15,

        [DisplayName("Citrix Desktop")]
        [Active(true)]
        [ParentId(10)]
        Citrix = 16,

        [DisplayName("VPN")]
        [Active(true)]
        [ParentId(10)]
        Vpn = 17,

        [DisplayName("Server Decommissioning")]
        [Active(true)]
        [ParentId(11)]
        ServerDecommissioning = 18,

        [DisplayName("Account Change")]
        [Active(true)]
        [ParentId(12)]
        AccountChange = 19,

        [DisplayName("Account Termination")]
        [Active(true)]
        [ParentId(12)]
        AccountTermination = 20
    }
}
