using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Abp.JobsManagement.Dtos
{
    public class MessageDto
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
    }
    public class JobProgressDto
    {
        public int Percentage { get; set; }
        public List<MessageDto> Messages { get; set; }

    }
}
