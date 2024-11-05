namespace Contracts.Events
{
    public class OutfitWornEvent
    {
        public int OutfitId { get; set; }
        public DateTime WornOn { get; set; }
        public int TimesWorn { get; set; }  // Incremented count of times worn
    }
}
