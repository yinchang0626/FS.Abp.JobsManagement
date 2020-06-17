using Volo.Abp.Auditing;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementDomainSharedModule),
        typeof(Volo.Abp.Domain.AbpDddDomainModule),
        typeof(Volo.Abp.BackgroundJobs.AbpBackgroundJobsDomainModule)
        )]
    public class JobsManagementDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAuditingOptions>(options =>
            {
                options.EntityHistorySelectors.AddAllEntities();
            });
        }
    }
}
