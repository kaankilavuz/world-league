using System.ComponentModel.DataAnnotations;
using WorldLeague.SharedKernel.Entities;

namespace WorldLeague.Domain.Entities
{
    public class League : CreationAuditedEntity<int>
    {
        #region Constants

        public const int CreatorNameMaxLength = 100;
        public const int CreatorSurnameMaxLength = 100;

        #endregion

        public string CreatorName { get; private set; }
        public string CreatorSurname { get; private set; }
        public short GroupCount { get; private set; }

        public List<Group> Groups { get; private set; }

        public League(
           [Required][MaxLength(CreatorNameMaxLength)] string creatorName,
           [Required][MaxLength(CreatorSurnameMaxLength)] string creatorSurname,
            short groupCount)
        {
            Groups = new List<Group>();

            SetCreatorName(creatorName);
            SetCreatorSurname(creatorSurname);
            SetGroupCount(groupCount);
        }

        public bool SetCreatorName(string creatorName)
        {
            Check(creatorName, nameof(CreatorName), CreatorNameMaxLength);
            CreatorName = creatorName;
            return true;
        }

        public bool SetCreatorSurname(string creatorSurname)
        {
            Check(creatorSurname, nameof(CreatorSurname), CreatorSurnameMaxLength);
            CreatorSurname = creatorSurname;
            return true;
        }

        public bool SetGroupCount(short groupCount)
        {
            if (groupCount != 4 && groupCount != 8)
                throw new Exception("Group count must be 4 or 8.");

            GroupCount = groupCount;

            if (groupCount == 4)
            {
                Groups.AddRange(new List<Group>()
                {
                    new Group("A", Id),
                    new Group("B", Id),
                    new Group("C", Id),
                    new Group("D", Id)
                });
            }
            else
            {
                Groups.AddRange(new List<Group>()
                {
                    new Group("A", Id),
                    new Group("B", Id),
                    new Group("C", Id),
                    new Group("D", Id),
                    new Group("E", Id),
                    new Group("F", Id),
                    new Group("G", Id),
                    new Group("H", Id)
                });
            }

            return true;
        }
    }
}
