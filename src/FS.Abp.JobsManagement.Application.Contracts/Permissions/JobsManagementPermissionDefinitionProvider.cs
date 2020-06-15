using FS.Abp.JobsManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FS.Abp.JobsManagement.Permissions
{
    public class JobsManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(JobsManagementPermissions.GroupName, L("Permission:JobsManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JobsManagementResource>(name);
        }
    }
}