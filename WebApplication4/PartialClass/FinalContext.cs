using Microsoft.EntityFrameworkCore;

namespace Travel.Admin.Models
{
    public partial class FinalContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(Config.GetConnectionString("final"));
            }

        }
    }
}
