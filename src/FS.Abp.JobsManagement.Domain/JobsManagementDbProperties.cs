namespace FS.Abp.JobsManagement
{
    public static class JobsManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "JobsManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "JobsManagement";
    }
}
