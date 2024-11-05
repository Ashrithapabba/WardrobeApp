namespace Contracts.Events
{
    public class OutfitScheduledEvent
    {
        public int OutfitId { get; set; }
        public string OutfitName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Occasion { get; set; }
    }
}
