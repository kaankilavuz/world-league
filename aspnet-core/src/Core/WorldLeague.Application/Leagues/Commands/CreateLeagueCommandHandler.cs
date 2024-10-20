using AutoMapper;
using MediatR;
using WorldLeague.Application.Leagues.Commons;
using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Helpers;
using WorldLeague.SharedKernel.Repositories;
using WorldLeague.SharedKernel.Uow;

namespace WorldLeague.Application.Leagues.Commands
{
    public sealed class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, LeagueDto>
    {
        private readonly IRepository<League, int> _leagueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly List<TeamSelectList> _teams;
        public CreateLeagueCommandHandler(
            IRepository<League, int> leagueRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _leagueRepository = leagueRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _teams = Team.GetShuffledTeams();
        }

        public async Task<LeagueDto> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
        {
            CheckGroupCount(request.GroupCount);
            League league = new(request.CreatorName, request.CreatorSurname, request.GroupCount);
            short groupIndex = 0;


            var teamsByCountry = _teams.GroupBy(t => t.CountryCode).ToDictionary(g => g.Key, g => g.ToList());
            var groupCountryMap = new Dictionary<int, HashSet<string>>();
            for (int i = 0; i < request.GroupCount; i++)
            {
                groupCountryMap[i] = new HashSet<string>();
            }

            while (teamsByCountry.Any(kvp => kvp.Value.Count > 0))
            {
                foreach (var country in teamsByCountry.Keys.ToList())
                {
                    var availableTeams = teamsByCountry[country];
                    if (availableTeams.Any())
                    {
                        var teamAdded = false;
                        while (!teamAdded)
                        {
                            if (!groupCountryMap[groupIndex].Contains(country))
                            {
                                var team = availableTeams.First();
                                league.Groups[groupIndex].AddTeam(team.Name, team.CountryCode);
                                groupCountryMap[groupIndex].Add(country);
                                teamsByCountry[country].Remove(team);
                                teamAdded = true;
                            }

                            groupIndex++;

                            if (groupIndex == league.GroupCount)
                            {
                                groupIndex = 0;
                            }
                        }
                    }
                }
            }

            var createdEntity = await _leagueRepository.InsertAsync(league, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LeagueDto>(createdEntity);
        }

        void CheckGroupCount(short groupCount)
        {
            if (groupCount != 4 && groupCount != 8)
                throw new Exception("Group count must be 4 or 8");
        }
    }
}
