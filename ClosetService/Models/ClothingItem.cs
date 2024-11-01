using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClosetService.Models
{
    public class ClothingItem
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public OutfitCategory Category { get; set; } // e.g., Tops, Bottoms, Shoes, etc.
    public string ImageUrl { get; set; }
    }
}