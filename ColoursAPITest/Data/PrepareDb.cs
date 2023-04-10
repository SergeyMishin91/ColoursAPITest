using Microsoft.EntityFrameworkCore;

namespace ColoursAPITest.Data
{
    public static class PrepareDb
    {
        public static void PeparePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }

        }

        private static void SeedData(ColourContext context)
        {
            context.Database.EnsureCreated();

            if (!context.ColourItems.Any())
            {
                context.ColourItems.AddRange(
                    new Models.Colour { Name = "Red" },
                    new Models.Colour { Name = "Yellow" },
                    new Models.Colour { Name = "Green" },
                    new Models.Colour { Name = "Blue" },
                    new Models.Colour { Name = "Black" }
                    );

                context.SaveChanges();
            }
        }
    }
}
