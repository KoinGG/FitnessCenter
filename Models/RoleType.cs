using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class RoleType
    {
        public RoleType()
        {
            Users = new HashSet<User>();
        }

        public int IdRoleType { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
