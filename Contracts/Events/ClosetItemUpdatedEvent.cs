using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class ClosetItemUpdatedEvent
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}