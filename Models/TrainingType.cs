using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class TrainingType
    {
        public TrainingType()
        {
            Training = new HashSet<Training>();
        }

        public int IdTrainingType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Training> Training { get; set; }
    }
}
