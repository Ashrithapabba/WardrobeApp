using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class OutfitDeletedEvent
    {
        public int OutfitId { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}