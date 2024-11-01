using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosetService.Models;

namespace ClosetService.DTOs
{
    public class ClothingItemDto
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public OutfitCategory Category { get; set; } // Uses the enum for categories like Tops, Bottoms, etc.
    public string ImageUrl { get; set; } 
    }
}