using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eicm.Core;
using Eicm.DataLayer.Entities.TypeCodes;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.Users;

namespace Eicm.DataLayer.Entities.Tickets
{
    [Table("Tickets", Schema = "Tickets")]
    public class Ticket : EntityBase
    {
        [StringLength(200, MinimumLength = 5)]
        [Required]
        public string Summary { get; set; }
        public int RequesterId { get; set; }
        public int? OwnerId { get; set; }
        public int? CauseId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int OriginId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public bool IsConfidential { get; set; }
        public bool IsVip { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<TicketComment> Comments { get; set; }

        public virtual User Requester { get; set; }
        public virtual User Owner { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Origin Origin { get; set; }
    }
}