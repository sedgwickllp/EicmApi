using Eicm.DataLayer.Entities.Tickets;
using System;

namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketNoteModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CreatedBy { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public bool ActiveInd { get; set; }
        public bool VisibleInd { get; set; }

        public TicketNoteModel(TicketComment note)
        {
            Id = note.Id;
            TicketId = note.TicketId;
            CreatedBy = note.CreatedByUserId;
            Comment = note.Comment;
            CreatedDateTime = note.CreatedDateTime;
            ActiveInd = note.IsActive;
            VisibleInd = note.IsVisibleToAll;
           
        }
    }
}
