using System;
using Eicm.Core.Enums;

namespace Eicm.Core.Models.ResponseModels
{
    public class AddSoftwareResponseModel : SoftwareModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }

    }   
}
