using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public class EfCoreEntityChangeRepository : EfCoreRepository<IAuditLoggingDbContext, EntityChange, Guid>, IEntityChangeRepository
    {
        public EfCoreEntityChangeRepository(IDbContextProvider<IAuditLoggingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<EntityChange>> FindByEntityIdAsync<TEntity>(Guid id)
            where TEntity:Volo.Abp.Domain.Entities.IEntity<Guid>
        {
            var entityFullName = typeof(TEntity).FullName;
            var entityId = id;
            return await GetQueryable().IncludeDetails()
                .Where(x => x.EntityTypeFullName == entityFullName.TruncateFromBeginning(EntityChangeConsts.MaxEntityTypeFullNameLength))
                .Where(x => x.EntityId == entityId.ToString())
                .ToListAsync();
        }
    }
}
