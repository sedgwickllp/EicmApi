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
        public Guid UserId { get; set; }
        public int BusinessExtension { get; set; }
        public int CellPhoneNumber { get; set; }
        public string MachineName { get; set; }
        public int LocationId { get; set; }
        public string Signature { get; set; }
        public int UserImageId { get; set; }
    }
}
