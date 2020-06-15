using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.JobsManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class JobsManagementPageModel : AbpPageModel
    {
        protected JobsManagementPageModel()
        {
            LocalizationResourceType = typeof(JobsManagementResource);
            ObjectMapperContext = typeof(JobsManagementWebModule);
        }
    }
}