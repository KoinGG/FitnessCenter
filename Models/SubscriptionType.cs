using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int IdSubscriptionType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
