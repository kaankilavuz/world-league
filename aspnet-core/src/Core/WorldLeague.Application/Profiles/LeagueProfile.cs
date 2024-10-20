using AutoMapper;
using WorldLeague.Application.Leagues.Commons;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Profiles
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<League, LeagueDto>();
            CreateMap<Group, GroupDto>()
                .ForMember(m => m.GroupName, src => src.MapFrom(s => s.Name));

            CreateMap<Team, TeamDto>();
        }
    }
}
