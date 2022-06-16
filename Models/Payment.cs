using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPayment { get; set; }
        public string Type { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
