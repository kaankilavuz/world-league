using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            using WorldLeagueDbContext context = serviceScope.ServiceProvider.GetRequiredService<WorldLeagueDbContext>();
            context.Database.Migrate();
        }
    }
}
