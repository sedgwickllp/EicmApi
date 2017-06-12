using System.ComponentModel.DataAnnotations.Schema;

namespace Eicm.DataLayer.Entities.Tickets
{
    [Table("TicketComments", Schema = "Tickets")]
    public class TicketComment : EntityBase
    {
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public bool IsVisibleToAll { get; set; }
    }
}