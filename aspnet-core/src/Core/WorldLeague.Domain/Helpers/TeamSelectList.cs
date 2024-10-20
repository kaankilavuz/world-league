namespace WorldLeague.Domain.Helpers
{
    public class TeamSelectList
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public TeamSelectList(
            string name,
            string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }
    }
}
