using FS.Abp.JobsManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.Abp.JobsManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(JobsManagementEntityFrameworkCoreTestModule)
        )]
    public class JobsManagementDomainTestModule : AbpModule
    {
        
    }
}
