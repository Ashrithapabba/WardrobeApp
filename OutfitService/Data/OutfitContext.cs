using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OutfitService.Models;

namespace OutfitService.Data
{
    public class OutfitContext : DbContext
    {
        public DbSet<Outfit> Outfits { get; set; }
        public OutfitContext(DbContextOptions<OutfitContext> options) : base(options) { }
        
    }
}