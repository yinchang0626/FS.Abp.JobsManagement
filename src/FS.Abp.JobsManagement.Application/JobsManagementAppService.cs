using FS.Abp.JobsManagement.Localization;
using Volo.Abp.Application.Services;

namespace FS.Abp.JobsManagement
{
    public abstract class JobsManagementAppService : ApplicationService
    {
        protected JobsManagementAppService()
        {
            LocalizationResource = typeof(JobsManagementResource);
            ObjectMapperContext = typeof(JobsManagementApplicationModule);
        }
    }
}
