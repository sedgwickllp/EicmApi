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
    public class ContactDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }
    }

}
