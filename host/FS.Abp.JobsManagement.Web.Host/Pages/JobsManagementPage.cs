using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using FS.Abp.JobsManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FS.Abp.JobsManagement.Pages
{
    public abstract class JobsManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<JobsManagementResource> L { get; set; }
    }
}
