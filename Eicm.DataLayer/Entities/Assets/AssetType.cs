using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Assets
{
    [Table("AssetTypes", Schema = "Assets")]
    public class AssetType : EntityBase
    {
        public string Name { get; set; }
    }
}