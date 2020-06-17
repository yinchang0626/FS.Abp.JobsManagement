using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.AuditLogging;
using Volo.Abp.Json;
using Volo.Abp.ObjectExtending.Modularity;

namespace FS.Abp.JobsManagement.Models
{
    public class JobDetail
    {
        protected IJsonSerializer JsonSerializer { get; }
        protected List<EntityChange> Datas { get; set; }

        public JobDetail(IJsonSerializer jsonSerializer,IList<EntityChange> datas)
        {
            this.JsonSerializer = jsonSerializer;
            this.Datas = datas.OrderBy(x=>x.ChangeTime).ToList();
        }
        private EntityChange createRecord
        {
            get 
            {
                return this.Datas.FirstOrDefault(x => x.ChangeType == Volo.Abp.Auditing.EntityChangeType.Created);
            }
        }
        private EntityChange deleteRecord
        {
            get 
            {
                return this.Datas.FirstOrDefault(x => x.ChangeType == Volo.Abp.Auditing.EntityChangeType.Deleted);
            }
        }
        private List<EntityChange> modifyRecords
        {
            get 
            {
                return this.Datas.Where(x => x.ChangeType == Volo.Abp.Auditing.EntityChangeType.Updated).OrderBy(x=>x.ChangeTime).ToList();
            }
        }

        public string JobId 
        {
            get 
            {
                return createRecord.EntityId;
            }
        }
        public string JobName
        {
            get
            {
                return createRecord.PropertyChanges.FirstOrDefault(x => x.PropertyName == nameof(Volo.Abp.BackgroundJobs.BackgroundJobRecord.JobName)).NewValue;
            }
        }
        public DateTime StartTime
        {
            get 
            {
                return createRecord.ChangeTime;
            }
        }
        public DateTime? EndTime
        {
            get
            {
                return deleteRecord?.ChangeTime;
            }
        }
        public List<JobProgress> JobProgress
        {
            get
            {
                var t=this.modifyRecords
                    .Select(x => x.PropertyChanges.FirstOrDefault(y => y.PropertyName == nameof(Volo.Abp.BackgroundJobs.BackgroundJobRecord.ExtraProperties))?.NewValue)
                    .Where(x => !string.IsNullOrEmpty(x));
                return t.Select(x => JsonSerializer.Deserialize<Dictionary<string,JObject>>(x)[nameof(JobProgress)].ToObject<JobProgress>()).ToList();
            }
        }

    }
}
