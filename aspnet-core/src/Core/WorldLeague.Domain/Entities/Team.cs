using System.ComponentModel.DataAnnotations;
using WorldLeague.Domain.Helpers;
using WorldLeague.SharedKernel.Entities;

namespace WorldLeague.Domain.Entities
{
    public class Team : BaseEntity<int>
    {
        #region Constants
        public const int NameMaxLength = 100;
        public const int CountryCodeNameMaxLength = 25;
        #endregion

        public string Name { get; private set; }
        public string CountryCode { get; private set; }
        public int GroupId { get; private set; }

        internal Team(
            [Required][MaxLength(NameMaxLength)] string name,
            [Required][MaxLength(CountryCodeNameMaxLength)] string countryCode,
            int groupId)
        {
            SetName(name);
            SetCountryCode(countryCode);
            GroupId = GroupId;
        }

        public bool SetName(string name)
        {
            Check(name, nameof(Name), NameMaxLength);
            Name = name;
            return true;
        }

        public bool SetCountryCode(string countryCode)
        {
            Check(countryCode, nameof(CountryCode), CountryCodeNameMaxLength);
            CountryCode = countryCode;
            return true;
        }

        public static List<TeamSelectList> GetShuffledTeams()
        {
            var teamsByCountry = new Dictionary<string, List<string>>
                                {
                                    { "TR", new List<string> { "Adesso İstanbul", "Adesso Ankara", "Adesso İzmir", "Adesso Antalya" } },
                                    { "GR", new List<string> { "Adesso Berlin", "Adesso Frankfurt", "Adesso Münih", "Adesso Dortmund" } },
                                    { "FR", new List<string> { "Adesso Paris", "Adesso Marsilya", "Adesso Nice", "Adesso Lyon" } },
                                    { "HL", new List<string> { "Adesso Amsterdam", "Adesso Rotterdam", "Adesso Lahey", "Adesso Eindhoven" } },
                                    { "PO", new List<string> { "Adesso Lisbon", "Adesso Porto", "Adesso Braga", "Adesso Coimbra" } },
                                    { "IT", new List<string> { "Adesso Roma", "Adesso Milano", "Adesso Venedik", "Adesso Napoli" } },
                                    { "IS", new List<string> { "Adesso Sevilla", "Adesso Madrid", "Adesso Barselona", "Adesso Granada" } },
                                    { "BEL", new List<string> { "Adesso Brüksel", "Adesso Brugge", "Adesso Gent", "Adesso Anvers" } }
                                };

            var teams = teamsByCountry.SelectMany(country => country.Value.Select(team => new TeamSelectList(team, country.Key))).ToList();
            var shuffledTeams = teams.OrderBy(t => new Random().Next()).ToList();
            return shuffledTeams;
        }
    }
}
