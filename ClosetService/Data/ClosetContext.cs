using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosetService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClosetService.Data
{
    public class ClosetContext : DbContext
    {
        public ClosetContext(DbContextOptions<ClosetContext> options) : base(options) { }
        public DbSet<ClothingItem> ClothingItems { get; set; }
    }
}