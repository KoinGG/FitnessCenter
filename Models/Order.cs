using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int IdOrderStatusType { get; set; }
        public int IdSubscriptionList { get; set; }
        public int IdCoach { get; set; }
        public int IdUser { get; set; }
        public int IdPayment { get; set; }

        public virtual Coach IdCoachNavigation { get; set; } = null!;
        public virtual OrderStatusType IdOrderStatusTypeNavigation { get; set; } = null!;
        public virtual Payment IdPaymentNavigation { get; set; } = null!;
        public virtual SubscriptionList IdSubscriptionListNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
