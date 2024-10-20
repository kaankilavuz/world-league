using Microsoft.Extensions.DependencyInjection;

namespace WorldLeague.Application.DIs
{
    public static class Dependencies
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services) => services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) => services.AddAutoMapper(typeof(Dependencies).Assembly);
    }
}
