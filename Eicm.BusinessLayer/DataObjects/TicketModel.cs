using System;
using System.Collections.Generic;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.Tickets;


namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Requestor { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Origin { get; set; }
        public string Category { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfidential { get; set; }
        public string Owner { get; set; }
        public ICollection<TicketNoteModel> Notes { get; set; }
        public TicketModel(Ticket ticket)
        {
            Id = ticket.Id;
            //Requestor = ticket.RequestedBy;
            Summary = ticket.Summary;
            CreatedDateTime = ticket.CreatedDateTime;
            ModifiedDate = ticket.ModifiedDateTime;
            Status = ((StatusType)ticket.StatusId).GetEnumDisplayName();
            Priority = ((PriorityType)ticket.PriorityId).GetEnumDisplayName();
            Origin = ((OriginType)ticket.OriginId).GetEnumDisplayName();
            if (ticket.CategoryId != null) Category = ((CategoryType) ticket.CategoryId).GetEnumDisplayName();
            if (ticket.SubCategoryId != null) Category = ((SubCategoryType)ticket.SubCategoryId).GetEnumDisplayName();
            if (ticket.CauseId != null) Category = ((CauseType)ticket.CauseId).GetEnumDisplayName();
            IsDeleted = ticket.IsDeleted;
            IsConfidential = ticket.IsConfidential;
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

    }

    
}
