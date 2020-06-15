using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public static partial class JobsManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureJobsManagement(
            this ModelBuilder builder,
            Action<JobsManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new JobsManagementModelBuilderConfigurationOptions(
                JobsManagementDbProperties.DbTablePrefix,
                JobsManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}