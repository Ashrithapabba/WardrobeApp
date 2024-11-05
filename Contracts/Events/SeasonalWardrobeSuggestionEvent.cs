using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public class SeasonalWardrobeSuggestionEvent
    {
        public List<int> SuggestedItemIds { get; set; }
        public string Season { get; set; }
        public DateTime SuggestedAt { get; set; }

    }
}