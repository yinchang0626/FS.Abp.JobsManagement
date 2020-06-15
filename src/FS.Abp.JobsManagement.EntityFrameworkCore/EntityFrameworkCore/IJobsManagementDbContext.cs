using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    [ConnectionStringName(JobsManagementDbProperties.ConnectionStringName)]
    public partial interface IJobsManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}