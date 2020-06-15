using Volo.Abp.Reflection;

namespace FS.Abp.JobsManagement.Permissions
{
    public class JobsManagementPermissions
    {
        public const string GroupName = "JobsManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(JobsManagementPermissions));
        }
    }
}