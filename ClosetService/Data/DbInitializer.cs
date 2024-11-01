using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ClosetService.Models;

namespace ClosetService.Data
{
    public static class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<ClosetContext>());
        
        }

        private static void SeedData(ClosetContext context)
        {
            context.Database.Migrate();

            if (context.ClothingItems.Any())
            {
                Console.WriteLine("Already have data - no need to seed");
                return;
            }
                var clothingItems = new List<ClothingItem>
                {
                    new ClothingItem { Name = "Blue T-Shirt", Category = OutfitCategory.Tops, ImageUrl = "/images/blue-tshirt.jpg" },
                    new ClothingItem { Name = "Black Jeans", Category = OutfitCategory.Bottoms, ImageUrl = "/images/black-jeans.jpg" },
                    new ClothingItem { Name = "White Sneakers", Category = OutfitCategory.Shoes, ImageUrl = "/images/white-sneakers.jpg" },
                    new ClothingItem { Name = "Leather Belt", Category = OutfitCategory.Accessories, ImageUrl = "/images/leather-belt.jpg" }
                };

                context.AddRange(clothingItems);
                context.SaveChanges();
        }
    }
}


            // Seed Outfits if none exist
//             if (!context.Outfits.Any())
//             {
//                 var outfit1 = new Outfit
//                 {
//                     Name = "Casual Outfit",
//                     ClothingItems = context.ClothingItems.Where(ci => ci.Name == "Blue T-Shirt" || ci.Name == "Black Jeans" || ci.Name == "White Sneakers").ToList(),
//                     CreatedAt = DateTime.Now
//                 };

//                 var outfit2 = new Outfit
//                 {
//                     Name = "Smart Casual",
//                     ClothingItems = context.ClothingItems.Where(ci => ci.Name == "Blue T-Shirt" || ci.Name == "Leather Belt").ToList(),
//                     CreatedAt = DateTime.Now
//                 };

//                 context.Outfits.AddRange(outfit1, outfit2);
//                 context.SaveChanges();
//             }
//         }
//     }
// }
