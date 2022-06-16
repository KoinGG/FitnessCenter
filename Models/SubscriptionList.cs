using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class SubscriptionList
    {
        public SubscriptionList()
        {
            Orders = new HashSet<Order>();
        }

        public int IdSubscriptionList { get; set; }
        public int IdSubscription { get; set; }

        public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
