namespace Eicm.BusinessLogic.DataObjects
{
    public class TicketAddDTO
    {
        public string Summary { get; set; }
        //public string Resolution { get; set; }
        public int? RequesterId { get; set; } //
        public int? OwnerId { get; set; }
        public int? CauseId { get; set; }
        public int? StatusId { get; set; }
        public int? PriorityId { get; set; }
        public int OriginId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public bool IsConfidential { get; set; }
        //public bool IsVip { get; set; } should get from the user
    }
}