﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eicm.DataLayer.Entities.TypeCodes
{
    [Table("Locations", Schema = "TypeCodes")]
    public class Location : EnumEntityBase
    {
    }
}
