namespace Contracts.Events
{
    public class ClosetItemAddedEvent
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
