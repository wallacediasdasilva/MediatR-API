using MediatRAPI.Domain.User;
using MediatRAPI.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MediatRAPI.Persistence.EFCore.Context
{
    public class MediatRContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }
        public MediatRContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public int SaveChangesByUser()
        {
            return base.SaveChanges();
        }
    }
}
