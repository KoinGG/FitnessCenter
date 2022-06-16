using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class training
    {
        public training()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int IdTraining { get; set; }
        public int IdTrainingType { get; set; }
        public string Time { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual TrainingType IdTrainingTypeNavigation { get; set; } = null!;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
