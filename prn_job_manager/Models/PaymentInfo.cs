using System;
using System.Collections.Generic;

namespace prn_job_manager.Models
{
    public partial class PaymentInfo
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
    }
}
