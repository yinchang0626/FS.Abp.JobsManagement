using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.JobsManagement.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits FS.Abp.JobsManagement.Web.Pages.JobsManagementPage
     */
    public abstract class JobsManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<JobsManagementResource> L { get; set; }
    }
}
