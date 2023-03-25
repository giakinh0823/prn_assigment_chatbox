using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prn_job_manager.Models
{
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Email không để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
