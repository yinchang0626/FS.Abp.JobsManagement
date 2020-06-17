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
    public class JobHistory
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public DateTime ExecuteStartTime { get; set; }
        public DateTime ExecuteEndTime { get; set; }
        public int ProgressCount { get; set; }
        public bool IsFinish { get; set; }
    }
}
