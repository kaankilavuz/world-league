using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL
{
    public class WorldLeagueDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public WorldLeagueDbContext(
            DbContextOptions options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default")).AddInterceptors(new Interceptors.SaveChangesInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorldLeagueDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
