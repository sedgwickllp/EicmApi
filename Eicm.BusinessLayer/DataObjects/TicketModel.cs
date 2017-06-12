using System;
using System.Collections.Generic;
using System.Linq;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.Tickets;


namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Requestor { get; set; }
        public string Description { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string RequestType { get; set; }
        public string Category { get; set; }
        public bool ActiveInd { get; set; }
        public string Owner { get; set; }
        public ICollection<TicketNoteModel> Notes { get; set; }
        public TicketModel(Ticket ticket)
        {
            Id = ticket.Id;
            //Requestor = ticket.RequestedBy;
            Description = ticket.Summary;
            EnteredDate = ticket.CreatedDateTime;
            ModifiedDate = ticket.ModifiedDateTime;
            Status = ((StatusType)ticket.StatusId).ToString();
            Priority = ((PriorityType)ticket.PriorityId).ToString();
            RequestType = ticket.RequestType?.ToString();
            Category = ((CategoryType)ticket.CategoryId).ToString();
            ActiveInd = ticket.IsActive;
            //Owner = ticket.Owner;
            //if there are notes, convert them to the notes model
            if (ticket.Comments != null)
            {
                //Notes = ticket.Comments.Select(n => (TicketNoteModel)n).ToList();
                //Notes = new Collection<TicketNote>();
                //foreach (var dbnote in ticket.Notes)
                //{
                //    if (dbnote.ActiveInd == true)
                //    {
                //        Notes.Add((TicketNote)dbnote);
                //    }
                //}
            }
            
        }
        //public static explicit operator Ticket(EnterpriseDataLayer.Entities.Tickets.Ticket t)
        //{
        //    return new Ticket(t);
        //}

        //public Ticket() {}
    }

    
}
