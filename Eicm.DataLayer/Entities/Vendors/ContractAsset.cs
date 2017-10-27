using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Assets;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("ContractAssets", Schema = "Vendors")]
    public class ContractAsset : EntityBase
    {
        public int ContractId { get; set; }
        public int AssetId { get; set; }
        public int LicenseType { get; set; }
        public int LicenseCount { get; set; }
        public int LocationId { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
