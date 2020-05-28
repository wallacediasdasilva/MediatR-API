using MediatRAPI.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatRAPI.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(e => e.Phone)
                   .IsRequired()
                   .HasMaxLength(11);
        }
    }
}
