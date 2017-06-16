using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Tickets
{
    [Table("TicketComments", Schema = "TicketsHistory")]
    public class TicketCommentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public int TicketCommentId { get; set; }
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public bool IsVisibleToAll { get; set; }
    }
}