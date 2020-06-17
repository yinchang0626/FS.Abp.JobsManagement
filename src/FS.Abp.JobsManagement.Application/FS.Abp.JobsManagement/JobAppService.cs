using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FS.Abp.JobsManagement.Dtos;
using FS.Abp.JobsManagement.Models;
using FS.Abp.JobsManagement.Sample;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.BackgroundJobs;

namespace FS.Abp.JobsManagement
{
    public class JobAppService : JobsManagementAppService, IJobAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IEntityChangeRepository entityChangeRepository;

        public JobAppService(
            IBackgroundJobManager backgroundJobManager,
            IEntityChangeRepository entityChangeRepository
            )
        {
            _backgroundJobManager = backgroundJobManager;
            this.entityChangeRepository = entityChangeRepository;
        }
        public async Task PostStartJobAsync()
        {
            await _backgroundJobManager.EnqueueAsync(
                new EmailSendingArgs
                {
                    EmailAddress = "",
                    Subject = "You've successfully registered!",
                    Body = "0"
                });
        }
        public async Task<List<JobHistoryDto>> GetJobHistoryAsync()
        {
            var models=await entityChangeRepository.ListJobHistoryAsync<Sample.EmailSendingArgs>();
            return ObjectMapper.Map<List<JobHistory>, List<JobHistoryDto>>(models);
        }
        public async Task<JobDetailDto> GetJobDetailAsync(string jobId)
        {
            var model = await entityChangeRepository.FindJobDetailAsync(jobId);
            return ObjectMapper.Map<JobDetail, JobDetailDto>(model);
        }
    }
}