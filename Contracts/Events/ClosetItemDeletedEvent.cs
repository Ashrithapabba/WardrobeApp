namespace Contracts.Events
{
    public class ClosetItemDeletedEvent
    {
        public int ItemId { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
