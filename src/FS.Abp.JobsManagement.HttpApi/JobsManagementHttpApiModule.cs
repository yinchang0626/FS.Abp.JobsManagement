using Localization.Resources.AbpUi;
using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Abp.JobsManagement
{
    [DependsOn(
        typeof(JobsManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class JobsManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(JobsManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<JobsManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
