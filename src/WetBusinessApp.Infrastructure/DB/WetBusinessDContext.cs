using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WetBusinessApp.Infrastructure.DB
{
    public class WetBusinessDContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public WetBusinessDContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WetBusinessDatabase"));
        }
    }
}
