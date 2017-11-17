namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketCommentAddModel
    {
        //public int? Id { get; set; }
        public int TicketId { get; set; }
        public string Comment { get; set; }
        public bool IsVisible { get; set; }
    }
}