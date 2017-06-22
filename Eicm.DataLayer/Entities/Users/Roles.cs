using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Users
{
    [Table("Roles", Schema = "Users")]
    public class Roles : EntityBase
    {      
        public string Name { get; set; }
    }
}
