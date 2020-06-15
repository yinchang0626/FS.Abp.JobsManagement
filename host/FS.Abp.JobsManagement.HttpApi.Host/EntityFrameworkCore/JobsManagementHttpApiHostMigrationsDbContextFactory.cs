using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public class JobsManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<JobsManagementHttpApiHostMigrationsDbContext>
    {
        public JobsManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<JobsManagementHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("JobsManagement"));

            return new JobsManagementHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
