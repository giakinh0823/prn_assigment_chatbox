using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class QrtzJobDetail
    {
        public QrtzJobDetail()
        {
            QrtzTriggers = new HashSet<QrtzTrigger>();
        }

        public string SchedName { get; set; } = null!;
        public string JobName { get; set; } = null!;
        public string JobGroup { get; set; } = null!;
        public string? Description { get; set; }
        public string JobClassName { get; set; } = null!;
        public string IsDurable { get; set; } = null!;
        public string IsNonconcurrent { get; set; } = null!;
        public string IsUpdateData { get; set; } = null!;
        public string RequestsRecovery { get; set; } = null!;
        public byte[]? JobData { get; set; }

        public virtual ICollection<QrtzTrigger> QrtzTriggers { get; set; }
    }
}
