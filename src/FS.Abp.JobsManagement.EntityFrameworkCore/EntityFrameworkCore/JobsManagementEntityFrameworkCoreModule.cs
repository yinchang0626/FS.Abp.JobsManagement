using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(JobsManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(Volo.Abp.BackgroundJobs.EntityFrameworkCore.AbpBackgroundJobsEntityFrameworkCoreModule)
    )]
    public class JobsManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JobsManagementDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
            context.Services.AddAbpDbContext<AbpAuditLoggingDbContext>(options =>
            {
                options.AddRepository<EntityChange, EfCoreEntityChangeRepository>();
            });
        }
    }
}