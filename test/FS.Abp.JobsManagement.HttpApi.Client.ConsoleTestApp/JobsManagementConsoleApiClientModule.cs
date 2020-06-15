using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class JobsManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
