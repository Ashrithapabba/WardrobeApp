using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutfitService.Models
{
public class Outfit
{
    public int Id { get; set; }
    public string Name { get; set; }           // Name of the outfit
    public DateTime? EventDate { get; set; }    // Date for scheduled events
    public string Occasion { get; set; }        // Occasion like Work, Casual, Formal
    public int TimesWorn { get; set; }          // Usage frequency for inventory tracking
    public bool IsSeasonal { get; set; }        // Indicates if the outfit is seasonal       // Additional notes for scheduling
}

}