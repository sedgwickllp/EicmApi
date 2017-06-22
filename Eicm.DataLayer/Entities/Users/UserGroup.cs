using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserGroups", Schema = "Users")]
    public class UserGroup : EntityBase
    {
        public Guid UserId { get; set; }
        public int GroupId { get; set; }
    }
}
