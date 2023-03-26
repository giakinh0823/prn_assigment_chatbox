using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
