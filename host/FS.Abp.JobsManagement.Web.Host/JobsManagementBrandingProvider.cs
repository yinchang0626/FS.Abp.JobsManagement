using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace FS.Abp.JobsManagement
{
    [Dependency(ReplaceServices = true)]
    public class JobsManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "JobsManagement";
    }
}
