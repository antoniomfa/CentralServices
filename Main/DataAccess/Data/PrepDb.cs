using CentralService.DataAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentralService.DataAccess.Data
{
    public static class PrepDb
    {
        public static void PrePopulate(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Seed(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }

        private static void Seed(AppDbContext dbContext, bool isProduction)
        {
            if (isProduction)
            {
                try
                {
                    Console.WriteLine("--> Applying Migrations ...");
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run Migrations: {ex.Message}");
                }
            }

            // If clean
            if (!dbContext.Platforms.Any())
            {
                System.Diagnostics.Debug.WriteLine("--> Seeding Data ...");

                dbContext.Platforms.AddRange(
                    new Platform() { Name = "PC", Brand = "AMD", Cost = "1500" },
                    new Platform() { Name = "PS5", Brand = "SONY", Cost = "700" },
                    new Platform() { Name = "XBOX", Brand = "MICROSOFT", Cost = "600" },
                    new Platform() { Name = "SWITCH", Brand = "NINTENDO", Cost = "500" });

                dbContext.SaveChanges();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("--> We already have Data ...");
            }
        }
    }
}
