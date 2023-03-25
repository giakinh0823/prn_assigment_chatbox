using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class JobSchedule
    {
        public int? JobId { get; set; }
        public int? Frequency { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? LastRun { get; set; }
        public DateTime? NextRun { get; set; }

        public virtual Job? Job { get; set; }
    }
}
