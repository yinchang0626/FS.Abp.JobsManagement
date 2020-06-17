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
using Volo.Abp.BackgroundJobs;
using System.Text.Json;
using Volo.Abp.Json;
using System.Runtime.CompilerServices;
using System.Linq.Dynamic.Core;
using FS.Abp.JobsManagement.Models;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public class EfCoreEntityChangeRepository :
        EfCoreRepository<IAuditLoggingDbContext, EntityChange, Guid>,
        IEntityChangeRepository
    {
        protected IJsonSerializer jsonSerializer { get; }
        public EfCoreEntityChangeRepository(
            IDbContextProvider<IAuditLoggingDbContext> dbContextProvider,
            IJsonSerializer jsonSerializer
            )
            : base(dbContextProvider)
        {
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<List<EntityChange>> ListByEntityIdAsync<TEntity>(Guid id)
            where TEntity : Volo.Abp.Domain.Entities.IEntity<Guid>
        {
            var entityFullName = typeof(TEntity).FullName;
            var entityId = id;
            return await GetQueryable().AsNoTracking().IncludeDetails()
                .Where(x => x.EntityTypeFullName == entityFullName.TruncateFromBeginning(EntityChangeConsts.MaxEntityTypeFullNameLength))
                .Where(x => x.EntityId == entityId.ToString())
                .ToListAsync();
        }

        public async Task<List<JobHistory>> ListJobHistoryAsync<TJobArgs>()
        {
            var jobName = JsonSerializer.Serialize(BackgroundJobNameAttribute.GetName<TJobArgs>());
            var entityFullName = typeof(Volo.Abp.BackgroundJobs.BackgroundJobRecord).FullName;
            var query = DbContext.Set<EntityChange>().AsNoTracking()
                .Where(x => x.EntityTypeFullName == entityFullName.TruncateFromBeginning(EntityChangeConsts.MaxEntityTypeFullNameLength))
                .Where(x => x.ChangeType == Volo.Abp.Auditing.EntityChangeType.Created)
                .Where(x => x.PropertyChanges.Any(y => y.PropertyName == nameof(BackgroundJobRecord.JobName) && y.NewValue == jobName))
                .Select(x => x.EntityId)
                .Distinct();
            var list = DbContext.Set<EntityChange>().AsNoTracking()
                .Where(x => query.Contains(x.EntityId));
            var result = await list.GroupBy(x => x.EntityId)
                .Select(x => new JobHistory
                {
                    JobId = x.Key,
                    JobName = jobName,
                    ExecuteStartTime = x.Min(y => y.ChangeTime),
                    ExecuteEndTime = x.Max(y => y.ChangeTime),
                    ProgressCount = x.Count(),
                    IsFinish = x.Max(p => p.ChangeType) == Volo.Abp.Auditing.EntityChangeType.Deleted
                }).ToListAsync();
            return result;

        }

        public async Task<JobDetail> FindJobDetailAsync(string jobId)
        {
            var list = await DbContext.Set<EntityChange>().AsNoTracking().IncludeDetails()
                .Where(x => x.EntityId == jobId)
                //.Where(x => x.ChangeTime >= startTime && x.ChangeTime <= endTime)
                .ToListAsync();

            return new JobDetail(jsonSerializer, list);



        }
    }
}
