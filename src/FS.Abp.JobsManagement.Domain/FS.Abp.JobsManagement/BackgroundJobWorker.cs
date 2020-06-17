using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace FS.Abp.JobsManagement
{
    [ExposeServices(typeof(IBackgroundJobWorker))]
    public class BackgroundJobWorker : Volo.Abp.BackgroundJobs.BackgroundJobWorker, IBackgroundJobWorker
    {
        public IAuditingManager AuditingManager { get; set; }
        public BackgroundJobWorker(
            AbpTimer timer,
            IOptions<AbpBackgroundJobOptions> jobOptions,
            IOptions<AbpBackgroundJobWorkerOptions> workerOptions,
            IServiceScopeFactory serviceScopeFactory
            )
            : base(timer, jobOptions, workerOptions, serviceScopeFactory) { }
        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            using (var scope = AuditingManager.BeginScope())
            {
                await base.DoWorkAsync(workerContext);
                await scope.SaveAsync();
            }
        }
    }
}
