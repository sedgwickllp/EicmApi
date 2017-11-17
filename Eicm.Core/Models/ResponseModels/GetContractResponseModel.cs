using System;
using System.Collections.Generic;

namespace Eicm.Core.Models.ResponseModels
{
    public class GetContractResponseModel : ContractModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedByUserId { get; set; }
        public bool IsActive { get; set; }
        //public List<AddSoftwareResponseModel> SoftwareList { get; set; }
    }

   
}
