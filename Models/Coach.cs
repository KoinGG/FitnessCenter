using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class Coach
    {
        public Coach()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCoach { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
