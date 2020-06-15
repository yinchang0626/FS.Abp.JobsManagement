using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementDomainSharedModule),
        typeof(FS.Abp.Domain.AbpDddDomainModule)
        )]
    public class JobsManagementDomainModule : AbpModule
    {

    }
}
