using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShumiLog.Data.Context
{
    internal class DesignTimeApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // TODO Aspire管理に統合
            optionsBuilder.UseMySql(new MySqlServerVersion(new System.Version(8, 1, 0)));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
