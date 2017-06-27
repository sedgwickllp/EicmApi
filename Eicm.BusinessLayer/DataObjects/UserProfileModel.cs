using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Users;
namespace Eicm.BusinessLogic.DataObjects
{
    public class UserProfileModel
    {

        public int UserId { get; set; }
        public int BusinessExtension { get; set; }
        public int CellPhoneNumber { get; set; }
        public string MachineName { get; set; }
        public string Signature { get; set; }       
        public UserLocation UserLocation { get; set; }
        public User User { get; set; }
        public UserProfileModel(UserProfile profile)
        {
            UserId = profile.UserId;
            BusinessExtension = profile.BusinessExtension;
            CellPhoneNumber = profile.CellPhoneNumber;
            MachineName = profile.MachineName;
            Signature = profile.Signature;
            UserLocation = profile.UserLocation;
            User = profile.User;

        }
    }
}
