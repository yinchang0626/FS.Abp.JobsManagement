using FS.Abp.JobsManagement.Models;
using Volo.Abp.Auditing;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace FS.Abp.JobsManagement.Sample
{
    [BackgroundJobName("EmailSending")]
    public class EmailSendingArgs: BackgroundJobArgs
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class EmailSendingJob : AsyncBackgroundJob<EmailSendingArgs>, ITransientDependency
    {

        public IAuditingManager AuditingManager { get; set; }
        private readonly IBackgroundJobRepository _backgroundJobRepository;
        public EmailSendingJob(
            IBackgroundJobRepository backgroundJobRepository
            )
        {
            this._backgroundJobRepository = backgroundJobRepository;
        }

        public override async System.Threading.Tasks.Task ExecuteAsync(EmailSendingArgs args)
        {
            var job = await _backgroundJobRepository.FindAsync(args.Id).ConfigureAwait(false);
            if (job.HasProperty(nameof(JobProgress)))
            {
                job.SetProperty(nameof(JobProgress), new JobProgress());
            }
            var progress = job.GetProperty<JobProgress>(nameof(JobProgress));

            for (var i = 0; i < 10; i++)
            {
                using (var scope = AuditingManager.BeginScope())
                {
                    progress.Percentage = (i + 1) * 10;
                    System.Threading.Thread.Sleep(1000);
                    job.SetProperty(nameof(JobProgress), progress);
                    await _backgroundJobRepository.UpdateAsync(job, true);
                    await scope.SaveAsync();
                }

            }


            
        }
    }
}
