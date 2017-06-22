using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
