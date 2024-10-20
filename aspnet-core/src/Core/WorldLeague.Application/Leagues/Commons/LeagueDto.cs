namespace WorldLeague.Application.Leagues.Commons
{
    public record LeagueDto
    {
        public List<GroupDto> Groups { get; init; } = new();
    }
}
