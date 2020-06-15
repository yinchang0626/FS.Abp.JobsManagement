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
        Task<List<EntityChange>> FindByEntityIdAsync<TEntity>(Guid id)
            where TEntity : Volo.Abp.Domain.Entities.IEntity<Guid>;
    }
}
