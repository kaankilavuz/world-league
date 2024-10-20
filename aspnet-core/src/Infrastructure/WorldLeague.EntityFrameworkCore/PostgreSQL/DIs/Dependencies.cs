using Microsoft.Extensions.DependencyInjection;
using WorldLeague.EntityFrameworkCore.PostgreSQL.Repositories;
using WorldLeague.EntityFrameworkCore.PostgreSQL.Uow;
using WorldLeague.SharedKernel.Repositories;
using WorldLeague.SharedKernel.Uow;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.DIs
{
    public static class Dependencies
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services) => services.AddDbContext<WorldLeagueDbContext>(ServiceLifetime.Scoped);
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped(typeof(IRepository<,>), typeof(EfCoreRepositoryBase<,>));
    }
}
