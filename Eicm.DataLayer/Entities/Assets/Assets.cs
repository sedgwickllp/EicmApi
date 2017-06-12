using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Assets
{
    [Table("Assets", Schema = "Assets")]
    public class Asset : EntityBase
    {
        public int AssetTypeId { get; set; }
        public string SerialNumber { get; set; }
    }
}
