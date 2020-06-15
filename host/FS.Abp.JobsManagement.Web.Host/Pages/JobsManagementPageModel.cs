using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.JobsManagement.Pages
{
    public abstract class JobsManagementPageModel : AbpPageModel
    {
        protected JobsManagementPageModel()
        {
            LocalizationResourceType = typeof(JobsManagementResource);
        }
    }
}