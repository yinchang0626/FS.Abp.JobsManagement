using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FS.Abp.JobsManagement.MongoDB
{
    public static class JobsManagementMongoDbContextExtensions
    {
        public static void ConfigureJobsManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new JobsManagementMongoModelBuilderConfigurationOptions(
                JobsManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}