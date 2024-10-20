using MediatR;
using System.ComponentModel.DataAnnotations;
using WorldLeague.Application.Leagues.Commons;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Leagues.Commands
{
    public record CreateLeagueCommand(
        [Required]
        [MaxLength(League.CreatorNameMaxLength)]
        string CreatorName,
        [Required]
        [MaxLength(League.CreatorSurnameMaxLength)]
        string CreatorSurname,
        [Required]
        short GroupCount) : IRequest<LeagueDto>;
}

