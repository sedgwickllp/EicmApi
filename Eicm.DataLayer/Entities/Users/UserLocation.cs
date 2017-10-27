using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("UserLocations", Schema = "Users")]
    public class UserLocation : EntityBase
    {
		public string Name { get; set; }
		public string TimeZone { get; set; }
    }
}
