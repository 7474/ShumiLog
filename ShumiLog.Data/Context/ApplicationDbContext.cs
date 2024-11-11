using Microsoft.EntityFrameworkCore;

namespace ShumiLog.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Model.WeatherForecast> WeatherForecasts { get; set; }
    }
}
