using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FS.Abp.JobsManagement
{
    public abstract class JobsManagementController : AbpController
    {
        protected JobsManagementController()
        {
            LocalizationResource = typeof(JobsManagementResource);
        }
    }
}
