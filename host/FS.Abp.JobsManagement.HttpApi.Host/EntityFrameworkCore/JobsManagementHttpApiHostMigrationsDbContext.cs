using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public class JobsManagementHttpApiHostMigrationsDbContext : AbpDbContext<JobsManagementHttpApiHostMigrationsDbContext>
    {
        public JobsManagementHttpApiHostMigrationsDbContext(DbContextOptions<JobsManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureJobsManagement();
        }
    }
}
