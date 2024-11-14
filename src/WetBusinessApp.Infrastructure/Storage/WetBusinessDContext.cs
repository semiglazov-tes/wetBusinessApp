using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WetBusinessApp.Infrastructure.Storage.Configuration;
using WetBusinessApp.Infrastructure.Storage.Entity;

namespace WetBusinessApp.Infrastructure.DB
{
    public class WetBusinessDContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<UserEntity> Users { get; set; }

        public WetBusinessDContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WetBusinessDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
