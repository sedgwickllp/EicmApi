﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.Vendors
{
    [Table("Contacts", Schema = "Vendors")]
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}
