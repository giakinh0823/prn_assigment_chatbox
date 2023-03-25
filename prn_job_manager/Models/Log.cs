using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int? JobId { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string Output { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
