using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserLocations", Schema = "Users")]
    public class UserLocation : EntityBase
    {
		public string Name { get; set; }
		public string TimeZone { get; set; }
    }
}
