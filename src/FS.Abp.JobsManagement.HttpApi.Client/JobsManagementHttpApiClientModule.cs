using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class JobsManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "JobsManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(JobsManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
