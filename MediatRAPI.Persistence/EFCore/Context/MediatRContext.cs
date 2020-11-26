using DDDAPI.Domain.Team;
using DDDAPI.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Persistence.EFCore.Context
{
    public class MediatRContext : DbContext
    {

        public DbSet<TeamEntity> Teams { get; set; }
        public MediatRContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public int SaveChangesByTeam()
        {
            return base.SaveChanges();
        }
    }
}
