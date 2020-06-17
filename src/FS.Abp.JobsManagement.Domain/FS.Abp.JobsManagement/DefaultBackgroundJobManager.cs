using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Timing;

namespace FS.Abp.JobsManagement
{
    [ExposeServices(typeof(IBackgroundJobManager))]
    public class DefaultBackgroundJobManager: Volo.Abp.BackgroundJobs.DefaultBackgroundJobManager, IBackgroundJobManager
    {
        public DefaultBackgroundJobManager(
            IClock clock,
            IBackgroundJobSerializer serializer,
            IBackgroundJobStore store,
            IGuidGenerator guidGenerator)
            : base(clock, serializer, store, guidGenerator) { }
        protected override async Task<Guid> EnqueueAsync(string jobName, object args, BackgroundJobPriority priority = BackgroundJobPriority.Normal, TimeSpan? delay = null)
        {
            var id = GuidGenerator.Create();
            if (args is BackgroundJobArgs)
            {
                (args as BackgroundJobArgs).Id = id;
            }
            var jobInfo = new BackgroundJobInfo
            {
                Id = id,
                JobName = jobName,
                JobArgs = Serializer.Serialize(args),
                Priority = priority,
                CreationTime = Clock.Now,
                NextTryTime = Clock.Now
            };

            if (delay.HasValue)
            {
                jobInfo.NextTryTime = Clock.Now.Add(delay.Value);
            }

            await Store.InsertAsync(jobInfo);

            return jobInfo.Id;
        }
    }

   
}
