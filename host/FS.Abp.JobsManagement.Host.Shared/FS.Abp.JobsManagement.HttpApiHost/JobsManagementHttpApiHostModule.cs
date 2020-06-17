using Microsoft.Extensions.DependencyInjection;
using FS.Abp.JobsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement.Host.HttpApi
{
    [DependsOn(
        typeof(JobsManagementApplicationModule),
        typeof(JobsManagementHttpApiModule),
        typeof(EntityFrameworkCore.JobsManagementEntityFrameworkCoreModule)
        )]
    public class JobsManagementHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(JobsManagementApplicationModule).Assembly, action => action.RootPath = "JobsManagement");
            });
        }
    }
}
