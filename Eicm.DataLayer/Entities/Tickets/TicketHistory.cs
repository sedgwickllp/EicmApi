using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Tickets
{
    [Table("Tickets", Schema = "TicketsHistory")]
    public class TicketHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public int TicketId { get; set; }
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

    }
}