using MediatR;
using WorldLeague.Application.Leagues.Commands;

namespace WorldLeague.Web.Api.Routers.Leagues
{
    public static class LeagueRouterExtensions
    {
        public const string URLPrefix = "api/leagues";
        public static IEndpointRouteBuilder MapLeagueRoutes(this IEndpointRouteBuilder app)
        {
            app.MapPost(URLPrefix, (IMediator mediator, CreateLeagueCommand input, CancellationToken cancellationToken) => mediator.Send(input, cancellationToken));

            return app;
        }
    }

}
