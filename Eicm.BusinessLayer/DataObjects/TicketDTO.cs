using System.Collections.Generic;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.Users;

namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketDTO
    {
        public TicketDetailModel TicketDetail;
        public TicketRequesterModel TicketRequester;
        public List<TicketActivityModel> TicketActivity;
        public List<TicketCommentsModel> TicketComments;
    }

    public class TicketDetailModel
    {
        public TicketDetailModel(int ticketId, string category, string subCategory, string origin, string createdDate, string status, string priority, string cause, string summary, bool isDeleted, bool isConfidential, bool isVip)
        {
            TicketId = ticketId;
            Category = category;
            SubCategory = subCategory;
            Origin = origin;
            CreatedDateTime = createdDate;
            Status = status;
            Priority = priority;
            Cause = cause;
            Summary = summary;
            IsDeleted = isDeleted;
            IsConfidential = isConfidential;
            IsVip = isVip;
        }

        public TicketDetailModel(Ticket ticket)
        {
            TicketId = ticket.Id;
            Status = ((StatusType)ticket.StatusId).GetEnumDisplayName();
            Priority = ((PriorityType)ticket.PriorityId).GetEnumDisplayName();
            Origin = ((OriginType)ticket.OriginId).GetEnumDisplayName();
            if (ticket.CategoryId != null) Category = ((CategoryType)ticket.CategoryId).GetEnumDisplayName();
            if (ticket.SubCategoryId != null) SubCategory = ((SubCategoryType)ticket.SubCategoryId).GetEnumDisplayName();
            if (ticket.CauseId != null) Cause = ((CauseType)ticket.CauseId).GetEnumDisplayName();
            CreatedDateTime = ticket.CreatedDateTime.ToShortDateString();
            Summary = ticket.Summary;
            IsDeleted = ticket.IsDeleted;
            IsConfidential = ticket.IsConfidential;
            IsVip = ticket.IsVip;
        }

        public TicketDetailModel() { }

        public int TicketId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Origin { get; set; }
        public string CreatedDateTime { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Cause { get; set; }
        public string Summary { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfidential { get; set; }
        public bool IsVip { get; set; }

    }

    public class TicketRequesterModel
    {
        public TicketRequesterModel(string fn, string ln, string email, string phone, string location)
        {
            FirstName = fn;
            LastName = ln;
            Email = email;
            Phone = phone;
            Location = location;
        }
        public TicketRequesterModel(UserProfile user)
        {
            FirstName = user.User.FirstName;
            LastName = user.User.LastName;
            Email = user.User.Email;
            Phone = user.BusinessExtension.ToString();
            Location = user.UserLocation.Name;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Location { get; }
    }

    public class TicketActivityModel
    {
        public TicketActivityModel(string un, string cd, string act, bool isComment, bool isCreated, bool isAssigned)
        {
            UserName = un;
            CreatedDate = cd;
            Activity = act;
            IsComment = isComment;
            IsCreated = isCreated;
            IsUpdated = IsUpdated;
        }
        public string UserName { get; }
        public string CreatedDate { get; }
        public string Activity { get; }
        public bool IsComment { get; }
        public bool IsCreated { get; }
        public bool IsUpdated { get; }
    }

    public class TicketCommentsModel
    {
        public TicketCommentsModel(string un, string cd, string com, bool isVisible, int ticketId)
        {
            UserName = un;
            CreatedDateTime = cd;
            Comment = com;
            IsVisible = isVisible;
            TicketId = ticketId;

        }
        public string UserName { get; }
        public string CreatedDateTime { get; }
        public string Comment { get; }
        public bool IsVisible { get; }
        public int TicketId { get; }
    }

}
