namespace WorldLeague.Application.Leagues.Commons
{
    public record GroupDto
    {
        public string GroupName { get; set; }
        public List<TeamDto> Teams { get; set; } = new();
    }
}
