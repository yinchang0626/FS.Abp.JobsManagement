using FS.Abp.JobsManagement.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FS.Abp.JobsManagement
{
    public interface IJobAppService : IApplicationService
    {
        Task PostStartJobAsync();

        Task<List<JobHistoryDto>> GetJobHistoryAsync();

        Task<JobDetailDto> GetJobDetailAsync(string jobId);
    }
}
