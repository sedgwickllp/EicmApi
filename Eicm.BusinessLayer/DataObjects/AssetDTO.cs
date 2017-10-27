using Eicm.DataLayer.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.BusinessLogic.DataObjects
{
    public class AssetModel
    {
        public int AssetId { get; set; }
        public string Description { get; set; }
        public int? CapabilityId { get; set; }
        public int? LicenseCount { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }

        public AssetModel(Asset asset)
        {
            AssetId = asset.Id;
            Description = asset.Description;
            CapabilityId = asset.CapabilityId; 
            LicenseCount = asset.LicenseCount;
            Name = asset.Name;
            CreatedDateTime = asset.CreatedDateTime;
            CreatedByUserId = asset.CreatedByUserId;
            ModifiedDateTime = asset.ModifiedDateTime;
            ModifedByUserId = asset.ModifedByUserId;
            IsActive = asset.IsActive;
        }

        public AssetModel(int id, string desc, int capabilityId, int licenseCount, string name, DateTime createdDateTime, int createdByUserId, DateTime modifiedDateTime, int modifiedByUserId)
        {
            AssetId = id;
            Description = desc;
            CapabilityId = capabilityId;
            LicenseCount = licenseCount;
            Name = name;
            CreatedDateTime = createdDateTime;
            CreatedByUserId = createdByUserId;
            ModifiedDateTime = modifiedDateTime;
            ModifedByUserId = modifiedByUserId;
        }
    }   
}
