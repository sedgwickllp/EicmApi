using System.Collections.Generic;

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
        public TicketDetailModel(int ticketId,string component, string subComponent, string category, string createdDate, string status, string priority, string source, string description)
        {
            TicketId = ticketId;
            Component = component;
            SubComponent = subComponent;
            Category = category;
            CreatedDate = createdDate;
            Status = status;
            Priority = priority;
            Source = source;
            Description = description;
        }
        public int TicketId { get; }
        public string Component { get; }
        public string SubComponent { get; }
        public string Category { get; }
        public string CreatedDate { get; }
        public string Status { get; }
        public string Priority { get; }
        public string Source { get; }
        public string Description { get; }
        
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
            IsAssigned = isAssigned;
        }
        public string UserName { get; }
        public string CreatedDate { get; }
        public string Activity { get; }
        public bool IsComment { get; }
        public bool IsCreated { get; }
        public bool IsAssigned { get; }
    }

    public class TicketCommentsModel
    {
        public TicketCommentsModel(string un, string cd, string com, bool isVisible)
        {
            UserName = un;
            CreatedDateTime = cd;
            Comment = com;
            IsVisible = isVisible;
        }
        public string UserName { get; }
        public string CreatedDateTime { get; }
        public string Comment { get; }
        public bool IsVisible { get; }
    }

}
