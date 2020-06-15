using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementApplicationModule),
        typeof(JobsManagementDomainTestModule)
        )]
    public class JobsManagementApplicationTestModule : AbpModule
    {

    }
}
