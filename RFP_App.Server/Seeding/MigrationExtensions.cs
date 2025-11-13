using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Seeding;

public static class MigrationExtensions
{
    public static async Task MigrateAndSeedAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var sp = scope.ServiceProvider;

        var db = sp.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync(); // ensure latest before seeding

        // Orchestrate seeders (order matters)
        var identity = sp.GetRequiredService<IIdentitySeeder>();
        await identity.SeedAsync();

        var appData = sp.GetRequiredService<IAppDataSeeder>();
        await appData.SeedAsync();
    }
}
