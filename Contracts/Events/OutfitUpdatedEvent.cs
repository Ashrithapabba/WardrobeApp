using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class OutfitUpdatedEvent
    {
        public int OutfitId { get; set; }
        public string OutfitName { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}