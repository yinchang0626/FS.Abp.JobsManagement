using System;

namespace FS.Abp.JobsManagement.Dtos
{
    public class JobHistoryDto
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public DateTime ExecuteStartTime { get; set; }
        public DateTime ExecuteEndTime { get; set; }
        public int ProgressCount { get; set; }
        public bool IsFinish { get; set; }
    }
}
