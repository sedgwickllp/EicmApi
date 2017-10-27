using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserProfiles", Schema = "Users")]
    public class UserProfile : EntityBase
    {
        public int UserId { get; set; }
        public int BusinessExtension { get; set; }
        public int CellPhoneNumber { get; set; }
        public string MachineName { get; set; }
        public int UserLocationId { get; set; }
        public string Signature { get; set; }
        public string Title { get; set; }
        public int UserImageId { get; set; }
        public virtual UserLocation UserLocation { get; set; }
        public virtual User User { get; set; }
    }
}
