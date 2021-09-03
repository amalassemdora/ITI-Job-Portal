using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Companies = new HashSet<Company>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
