using System.ComponentModel.DataAnnotations;
using WorldLeague.SharedKernel.Entities;

namespace WorldLeague.Domain.Entities
{
    public class Group : BaseEntity<int>
    {
        #region Constants
        public const int NameMaxLength = 100;
        #endregion

        public string Name { get; private set; }
        public int LeagueId { get; private set; }

        public List<Team> Teams { get; private set; }

        internal Group(
            [Required][MaxLength(NameMaxLength)] string name,
            int leagueId)
        {
            SetName(name);
            LeagueId = leagueId;

            Teams = new List<Team>();
        }

        public bool SetName([Required] string name)
        {
            Check(name, nameof(Name), NameMaxLength);
            Name = name;
            return true;
        }

        public bool AddTeam(
            [Required] string name,
            [Required] string countryCode)
        {
            Teams.Add(new Team(name, countryCode, Id));
            return true;
        }
    }
}
