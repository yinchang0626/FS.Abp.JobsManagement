using AutoMapper;
using FS.Abp.JobsManagement.Dtos;
using FS.Abp.JobsManagement.Models;

namespace FS.Abp.JobsManagement
{
    public class JobsManagementApplicationAutoMapperProfile : Profile
    {
        public JobsManagementApplicationAutoMapperProfile()
        {

            this.CreateMap<JobDetail, JobDetailDto>();
            this.CreateMap<JobHistory, JobHistoryDto>();
            this.CreateMap<JobProgress, JobProgressDto>();
            this.CreateMap<Message, MessageDto>();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}