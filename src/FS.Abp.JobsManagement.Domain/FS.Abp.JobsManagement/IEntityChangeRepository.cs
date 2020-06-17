using FS.Abp.JobsManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace FS.Abp.JobsManagement
{
    public interface IEntityChangeRepository:IRepository<EntityChange,Guid>
    {
        Task<List<EntityChange>> ListByEntityIdAsync<TEntity>(Guid id)
            where TEntity : Volo.Abp.Domain.Entities.IEntity<Guid>;
        Task<List<JobHistory>> ListJobHistoryAsync<TJobArgs>();
        Task<JobDetail> FindJobDetailAsync(string jobId);
    }
}
