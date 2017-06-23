using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Users;
namespace Eicm.BusinessLogic.DataObjects
{
    public class UserModel
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel(User user)
        {
            Id = user.Id;
            UserId = user.UserId;
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
