using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities
{
    public abstract class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }
    }
}