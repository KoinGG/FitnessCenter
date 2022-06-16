using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int IdRoleType { get; set; }

        public virtual RoleType IdRoleTypeNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
