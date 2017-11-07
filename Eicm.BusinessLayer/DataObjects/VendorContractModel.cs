using Eicm.DataLayer.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.BusinessLogic.DataObjects
{
    public class VendorContractModel
    {
        public VendorDetailModel VendorDetail;
        //public List<VendorAccountsModel> VendorAccounts;
        public List<VendorContactModel> Contacts { get; set; }
        public List<ContractDetailModel> VendorContracts { get; set; }
    }
}
