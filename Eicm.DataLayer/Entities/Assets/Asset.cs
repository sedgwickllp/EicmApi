using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Eicm.DataLayer.Entities.Assets
{
    [Table("Assets", Schema = "Assets")]
    public class Asset : EntityBase
    {
        public int AssetTypeId { get; set; }
        public string Name { get; set; }
        public int? CapabilityId { get; set; }
        public int? LicenseCount { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelId { get; set; }
        public string SerialNumber { get; set; }
        public int? OfficeId { get; set; }
        public string Description { get; set; }
        public int? AvgDailyUsers { get; set; }
        public int? UserRangeId { get; set; }
        public string Version { get; set; }
        public string ModelYear { get; set; }
        public int? AssetCategoryId { get; set; }
        public int? DollarThresholdId { get; set; }
        public int? TempId { get; set; }
    }
}
