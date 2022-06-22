using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class Schedule
    {
        public Schedule()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int IdSchedule { get; set; }
        public int IdTraining { get; set; }
        public int TrainingCount { get; set; }

        public virtual Training IdTrainingNavigation { get; set; } = null!;
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
