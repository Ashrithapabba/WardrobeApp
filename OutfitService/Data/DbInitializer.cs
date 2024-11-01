using Microsoft.EntityFrameworkCore;
using OutfitService.Models;

namespace OutfitService.Data
{
    public static class DbInitializer
{
    public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<OutfitContext>());
        
        }
    public static void SeedData(OutfitContext context)
    {
        context.Database.Migrate();

        if (context.Outfits.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
                return;
        }

        var outfititems = new List<Outfit>
        {
            new Outfit
            {
                Name = "Business Casual",
                EventDate = DateTime.Now.AddDays(2),
                Occasion = "Work",
                TimesWorn = 3,
                IsSeasonal = false
            },
            new Outfit
            {
                Name = "Summer Beach",
                EventDate = DateTime.Now.AddDays(1),
                Occasion = "Casual",
                TimesWorn = 5,
                IsSeasonal = true
            },
             new Outfit
            {
                Name = "Gym",
                EventDate = DateTime.Now.AddDays(4),
                Occasion = "Workout",
                TimesWorn = 5,
                IsSeasonal = true
            }
        };
        context.AddRange(outfititems);
        context.SaveChanges();
    }
}

}