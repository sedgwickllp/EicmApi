using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("Groups", Schema = "Users")]
    public class Group : EntityBase
    {
        public int AdId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
