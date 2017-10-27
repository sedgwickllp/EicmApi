using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserGroups", Schema = "Users")]
    public class UserGroup : EntityBase
    {
        public Guid UserId { get; set; }
        public int GroupId { get; set; }
    }
}
