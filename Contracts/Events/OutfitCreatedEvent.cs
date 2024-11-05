using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class OutfitCreatedEvent
    {
        public int OutfitId { get; set; }
        public string OutfitName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}