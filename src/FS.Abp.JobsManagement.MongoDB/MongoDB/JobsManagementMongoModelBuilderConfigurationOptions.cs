using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace FS.Abp.JobsManagement.MongoDB
{
    public class JobsManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public JobsManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}