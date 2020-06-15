using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement.MongoDB
{
    [DependsOn(
        typeof(JobsManagementTestBaseModule),
        typeof(JobsManagementMongoDbModule)
        )]
    public class JobsManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}