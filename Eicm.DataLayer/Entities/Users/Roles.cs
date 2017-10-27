using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("Roles", Schema = "Users")]
    public class Roles : EntityBase
    {      
        public string Name { get; set; }
    }
}
