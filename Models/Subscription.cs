using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class Subscription
    {
        public Subscription()
        {
            SubscriptionLists = new HashSet<SubscriptionList>();
        }

        public int IdSubscription { get; set; }
        public int VisitsAmount { get; set; }
        public DateTime Validity { get; set; }
        public int IdSubscriptionType { get; set; }
        public int IdSchedule { get; set; }
        public decimal Cost { get; set; }

        public virtual Schedule IdScheduleNavigation { get; set; } = null!;
        public virtual SubscriptionType IdSubscriptionTypeNavigation { get; set; } = null!;
        public virtual ICollection<SubscriptionList> SubscriptionLists { get; set; }
    }
}
