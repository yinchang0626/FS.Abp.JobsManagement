using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FS.Abp.JobsManagement.MongoDB
{
    [ConnectionStringName(JobsManagementDbProperties.ConnectionStringName)]
    public class JobsManagementMongoDbContext : AbpMongoDbContext, IJobsManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureJobsManagement();
        }
    }
}