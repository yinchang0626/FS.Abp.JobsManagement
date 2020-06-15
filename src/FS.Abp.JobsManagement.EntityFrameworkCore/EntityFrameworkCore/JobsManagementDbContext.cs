using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    [ConnectionStringName(JobsManagementDbProperties.ConnectionStringName)]
    public partial class JobsManagementDbContext : AbpDbContext<JobsManagementDbContext>, IJobsManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public JobsManagementDbContext(DbContextOptions<JobsManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureJobsManagement();

            base.OnModelCreating(builder);
        }
    }
}