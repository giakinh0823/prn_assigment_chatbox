using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class Job
    {
        public Job()
        {
            Logs = new HashSet<Log>();
        }

        public int JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Webhook { get; set; }
        public string Payload { get; set; }
        public string Header { get; set; }
        public string Method { get; set; }
        public string Expression { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
