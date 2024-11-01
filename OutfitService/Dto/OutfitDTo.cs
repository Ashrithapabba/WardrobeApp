using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutfitService.Dto
{
    public class OutfitDTo
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? EventDate { get; set; }
    public string Occasion { get; set; }
    public int TimesWorn { get; set; }
    public bool IsSeasonal { get; set; }
    }
}