using DDDAPI.Domain.Team;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDAPI.Persistence.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.Modality)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.QtdPlayers)
                   .IsRequired()
                   .HasMaxLength(11);
        }
    }
}
