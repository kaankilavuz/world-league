using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeague.Domain.Entities;

namespace WorldLeague.EntityFrameworkCore.PostgreSQL.EntityTypeConfigurations
{
    public sealed class LeagueEntityTypeConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.ToTable("Leagues");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);


            builder.OwnsMany(lotsOwnsMany => lotsOwnsMany.Groups, groupsAct =>
            {
                groupsAct.ToTable("Groups");
                groupsAct.HasKey(x => x.Id);
                groupsAct.WithOwner().HasForeignKey(fk => fk.LeagueId);
                groupsAct.Property(p => p.Name).IsRequired().HasMaxLength(Group.NameMaxLength);

                groupsAct.OwnsMany(groupsOwnsMany => groupsOwnsMany.Teams, teamsAct =>
                {
                    teamsAct.ToTable("Teams");
                    teamsAct.HasKey(x => x.Id);
                    teamsAct.WithOwner().HasForeignKey(fk => fk.GroupId);
                    teamsAct.Property(p => p.Name).IsRequired().HasMaxLength(Team.NameMaxLength);
                    teamsAct.Property(p => p.CountryCode).IsRequired().HasMaxLength(Team.CountryCodeNameMaxLength);
                });
            });
        }
    }
}
