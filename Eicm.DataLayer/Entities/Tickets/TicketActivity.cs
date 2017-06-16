using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Tickets
{
    [Table("TicketActivities", Schema = "Tickets")]
    public class TicketActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketActivityId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ActivityId { get; set; }
        public int TicketId { get; set; }
        public int TicketPropertyId { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }

    }
}