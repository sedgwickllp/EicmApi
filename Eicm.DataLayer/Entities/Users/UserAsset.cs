using System;
using System.ComponentModel.DataAnnotations.Schema;
using Eicm.DataLayer.Entities.Assets;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserAssets", Schema = "Users")]
    public class UserAsset : EntityBase
    {
        public Guid UserId { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual User User { get; set; }
    }
}
