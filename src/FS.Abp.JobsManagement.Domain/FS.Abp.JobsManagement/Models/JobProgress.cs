using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Abp.JobsManagement.Models
{
    public class Message
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public Message()
        {
            DateTime = DateTime.Now;
        }
    }
    public class JobProgress
    {
        public int Percentage { get; set; }
        public List<Message> Messages { get; set; }
        public JobProgress()
        {
            Messages = new List<Message>();
        }

    }
}
