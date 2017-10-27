using Eicm.Core.Attributes;

namespace Eicm.Core.Enums
{
    public enum CapabilityType
    {
        //2-Factor Authentication
        [DisplayName("2-Factor Authentication")]
        [Active(true)]
        TwoFactorAuth = 0,
        //3rd Party Engineering
        [DisplayName("3rd Party Engineering")]
        [Active(true)]
        ThirdPartyEngineering= 1,
        //3rd Party Application Dev.
        [DisplayName("3rd Party Application Dev.")]
        [Active(true)]
        ThirdPartyAppDev = 2,
        //3rd Party Customer Support
        [DisplayName("3rd Party Customer Support")]
        [Active(true)]
        ThirdPartyCustomerSupport = 3,
        //3rd Party Consulting
        [DisplayName("3rd Party Consulting")]
        [Active(true)]
        ThirdPartyConsulting = 4,
        //Accounts Payable
        [DisplayName("Accounts Payable")]
        [Active(true)]
        AccountsPayable = 5,
        //Application Dev. Tools
        [DisplayName("Application Dev. Tools")]
        [Active(true)]
        ApplicationDevTools = 6,
        //Antivirus
        [DisplayName("Antivirus")]
        [Active(true)]
        Antivirus = 7,
        //AR Collections
        [DisplayName("AR Collections")]
        [Active(true)]
        ArCollections = 8,
        //Audio Visual
        [DisplayName("Audio Visual")]
        [Active(true)]
        AudioVisual = 9,
        //Back-up management
        [DisplayName("Back-up management")]
        [Active(true)]
        BackupManagement = 10,
        //Blackberry Management
        [DisplayName("Blackberry Management")]
        [Active(true)]
        BlackberryManagement = 11,
        //Budgeting
        [DisplayName("Budgeting")]
        [Active(true)]
        Budgeting = 12,
        //Business Intelligence
        [DisplayName("Business Intelligence")]
        [Active(true)]
        BusinessIntelligence = 13,
        //Case Organization
        [DisplayName("Case Organization")]
        [Active(true)]
        CaseOrganization = 14,
        //Compute Equipment
        [DisplayName("ComputeEquipment")]
        [Active(true)]
        ComputeEquipment = 15,
        //Conflicts Management
        [DisplayName("Conflicts Management")]
        [Active(true)]
        ConflictsManagement = 16,
        //CRM
        [DisplayName("CRM")]
        [Active(true)]
        Crm = 17,
        //Currency Authority
        [DisplayName("Currency Authority")]
        [Active(true)]
        CurrencyAuthority = 18,
        //Database
        [DisplayName("Database")]
        [Active(true)]
        Database = 19,
        //Data Center
        [DisplayName("Data Center")]
        [Active(true)]
        DataCenter = 20,
        //Desktop Foundational Apps
        [DisplayName("Desktop Foundational Apps")]
        [Active(true)]
        DesktopFoundationalApps = 21,
        //Dictation
        [DisplayName("Dictation")]
        [Active(true)]
        Dictation = 22,
        //Disaster Recovery
        [DisplayName("Disaster Recovery")]
        [Active(true)]
        DisasterRecovery = 23,
        //Docketing & Calendar
        [DisplayName("Docketing & Calendar")]
        [Active(true)]
        DocketingCalendar = 24,
        //Document Conversion
        [DisplayName("Document Conversion")]
        [Active(true)]
        DocumentConversion = 25,
        //Document Metadata Stripping
        [DisplayName("Document Metadata Stripping")]
        [Active(true)]
        DocumentMetadataStripping = 26,
        //Document Management (DMS)
        [DisplayName("Document Management (DMS)")]
        [Active(true)]
        DMS = 27,
        //eDiscovery
        [DisplayName("eDiscovery")]
        [Active(true)]
        eDiscovery = 28,
        //Email Filtering
        [DisplayName("Email Filtering")]
        [Active(true)]
        EmailFiltering = 29,
        //Equipment Purchasing
        [DisplayName("Equipment Purchasing")]
        [Active(true)]
        EquipmentPurchasing = 30,
        //Equitrac
        [DisplayName("Equitrac")]
        [Active(true)]
        Equitrac = 31,
        //Ethical Walls
        [DisplayName("Ethical Walls")]
        [Active(true)]
        EthicalWalls = 32,
        //Facility Maintenance
        [DisplayName("Facility Maintenance")]
        [Active(true)]
        FacilityMaintenance = 33,
        //Financials - QuickBooks
        [DisplayName("Financials - QuickBooks")]
        [Active(true)]
        FinancialsQuickBooks = 34,
        //HR - Talent Management
        [DisplayName("HR - Talent Management")]
        [Active(true)]
        HRTalentManagement = 35,
        //HR - Benefits
        [DisplayName("HR - Benefits")]
        [Active(true)]
        HRBenefits = 36,
        //HR - Compensation
        [DisplayName("HR - Compensation")]
        [Active(true)]
        HRCompensation = 37,
        //HR - Recruiting
        [DisplayName("HR - Recruiting")]
        [Active(true)]
        HRRecruiting = 38,
        //HR - Performance Management
        [DisplayName("HR - Performance Management")]
        [Active(true)]
        HRPerformanceManagement = 39,
        //HVAC
        [DisplayName("HVAC")]
        [Active(true)]
        HVAC = 40,
        //Infrastructure Equipment
        [DisplayName("Infrastructure Equipment")]
        [Active(true)]
        InfrastructureEquipment = 41,
        //Insurance
        [DisplayName("Insurance")]
        [Active(true)]
        Insurance = 42,
        //Intellectual Property
        [DisplayName("Intellectual Property")]
        [Active(true)]
        IntellectualProperty = 43,

        //Learning Management
        [DisplayName("Learning Management")]
        [Active(true)]
        LearningManagement = 44,
        //Learning Management Site (LMS)
        [DisplayName("Learning Management Site (LMS)")]
        [Active(true)]
        LearningManagementSite = 45,
        //Legal Accounting/Financials
        [DisplayName("Legal Accounting/Financials")]
        [Active(true)]
        LegalAccountingFinancials = 46,
        //Legal Document Format/Repair
        [DisplayName("Legal Document Format/Repair")]
        [Active(true)]
        LegalDocumentFormatRepair = 47,
        //Legal Holds
        [DisplayName("Legal Holds")]
        [Active(true)]
        LegalHolds = 48,
        //Legal Templates
        [DisplayName("Legal Templates")]
        [Active(true)]
        LegalTemplates = 49,
        //Legal/Trial Case Presentation
        [DisplayName("Legal/Trial Case Presentation")]
        [Active(true)]
        LegalTrialCasePresentation = 50,
        //Meeting Scheduler
        [DisplayName("Meeting Scheduler")]
        [Active(true)]
        MeetingScheduler = 51,
        //Microsoft
        [DisplayName("Microsoft")]
        [Active(true)]
        Microsoft = 52,
        //Mobile Device Management
        [DisplayName("Mobile Device Management")]
        [Active(true)]
        MobileDeviceManagement = 53,
        //Monitoring
        [DisplayName("Monitoring")]
        [Active(true)]
        Monitoring = 54,
        //MS Office Add-In
        [DisplayName("MS Office Add-In")]
        [Active(true)]
        MSOfficeAddIn = 55,
        //Network Equipment
        [DisplayName("Network Equipment")]
        [Active(true)]
        NetworkEquipment = 56,
        //Network Mapping
        [DisplayName("Network Mapping")]
        [Active(true)]
        NetworkMapping = 57,
        //PDF Creation/Management
        [DisplayName("PDF Creation/Management")]
        [Active(true)]
        PDFCreationManagement = 58,
        //Phishing Isolation Services
        [DisplayName("Phishing Isolation Services")]
        [Active(true)]
        PhishingIsolationServices = 59,
        //Prebill Viewer
        [DisplayName("Prebill Viewer")]
        [Active(true)]
        PrebillViewer = 60,
        //Print Server Management
        [DisplayName("Print Server Management")]
        [Active(true)]
        PrintServerManagement = 61,
        //Professional Services - Engineering Resources
        [DisplayName("Professional Services - Engineering Resources")]
        [Active(true)]
        ProfessionalServicesEngineeringResources = 62,
        //Project Management
        [DisplayName("Project Management")]
        [Active(true)]
        ProjectManagement = 63,
        // Quarantine/Containerization
        [DisplayName("Quarantine/Containerization")]
        [Active(true)]
        QuarantineContainerization = 64,
        //Remote Access
        [DisplayName("Remote Access")]
        [Active(true)]
        RemoteAccess = 65,
        //Remote Support
        [DisplayName("Remote Support")]
        [Active(true)]
        RemoteSupport = 66,
        //Room Scheduling
        [DisplayName("Room Scheduling")]
        [Active(true)]
        RoomScheduling = 67,

        //Screen Capture
        [DisplayName("Screen Capture")]
        [Active(true)]
        ScreenCapture = 68,
        //Secure Document Sharing
        [DisplayName("Secure Document Sharing")]
        [Active(true)]
        SecureDocumentSharing = 69,
        //Secure User Activity Tracking
        [DisplayName("Secure User Activity Tracking")]
        [Active(true)]
        SecureUserActivityTracking = 70,
        //Security Awareness & Training
        [DisplayName("Security Awareness & Training")]
        [Active(true)]
        SecurityAwarenessTraining = 71,
        //Security Monitoring/Management
        [DisplayName("Security Monitoring/Management")]
        [Active(true)]
        SecurityMonitoringManagement = 72,
        //Server Monitoring/Management
        [DisplayName("Server Monitoring/Management")]
        [Active(true)]
        ServerMonitoringManagement = 73,
        //Service Desk Ticketing
        [DisplayName("Service Desk Ticketing")]
        [Active(true)]
        ServiceDeskTicketing = 74,
        //Single Sign-On Service
        [DisplayName("Single Sign-On Service")]
        [Active(true)]
        SingleSignOnService = 75,
        //Storage Equipment
        [DisplayName("Storage Equipment")]
        [Active(true)]
        StorageEquipment = 76,
        //System Log Management
        [DisplayName("System Log Management")]
        [Active(true)]
        SystemLogManagement = 77,
        //Talent Management
        [DisplayName("Talent Management")]
        [Active(true)]
        TalentManagement = 78,
        //Technology Change Control
        [DisplayName("Technology Change Control")]
        [Active(true)]
        TechnologyChangeControl = 79,
        //Telecom - Voice
        [DisplayName("Telecom - Voice")]
        [Active(true)]
        TelecomVoice = 80,
        //Telecom - Data
        [DisplayName("Telecom - Data")]
        [Active(true)]
        TelecomData = 81,
        //UK Knowledge Library
        [DisplayName("UK Knowledge Library")]
        [Active(true)]
        UKKnowledgeLibrary = 82,
        //Virtual Remote Capability
        [DisplayName("Virtual Remote Capability")]
        [Active(true)]
        VirtualRemoteCapability = 83,
        //Web Security
        [DisplayName("Web Security")]
        [Active(true)]
        WebSecurity = 84,
        //Work Station Log-in
        [DisplayName("Work Station Log-in")]
        [Active(true)]
        WorkStationLogin = 85,
        //Xray Review
        [DisplayName("Xray Review")]
        [Active(true)]
        XrayReview = 86
    }
}