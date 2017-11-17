using Eicm.Core.Enums;

namespace Eicm.Core.Models
{
    public class SoftwareModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int? CapabilityType { get; set; }
        public int? CriticalityId { get; set; }
        public int? LicenseType { get; set; }
        public int? LicenseCount { get; set; }
        public int? AvgDailyUsers { get; set; }
        public int? UserRangeType { get; set; }
    }   
}
