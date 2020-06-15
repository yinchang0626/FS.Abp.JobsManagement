using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public partial class JobsManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public JobsManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}