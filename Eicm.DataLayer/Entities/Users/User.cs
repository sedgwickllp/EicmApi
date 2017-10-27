using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("Users", Schema = "Users")]
    public class User : EntityBase
    {
        public Guid? AdId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

    }
}
