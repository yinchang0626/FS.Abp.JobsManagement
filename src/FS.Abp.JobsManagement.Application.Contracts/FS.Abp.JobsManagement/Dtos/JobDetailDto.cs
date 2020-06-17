using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Json;
using Volo.Abp.ObjectExtending.Modularity;

namespace FS.Abp.JobsManagement.Dtos
{
    public class JobDetailDto
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<JobProgressDto> JobProgress { get; set; }

    }
}
