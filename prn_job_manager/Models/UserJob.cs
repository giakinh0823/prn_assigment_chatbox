using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class UserJob
    {
        public int? UserId { get; set; }
        public int? JobId { get; set; }

        public virtual Job? Job { get; set; }
        public virtual User? User { get; set; }
    }
}
