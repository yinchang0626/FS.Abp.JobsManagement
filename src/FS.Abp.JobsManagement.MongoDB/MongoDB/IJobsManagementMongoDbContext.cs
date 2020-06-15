using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.JobsManagement.MongoDB
{
    [ConnectionStringName(JobsManagementDbProperties.ConnectionStringName)]
    public interface IJobsManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
