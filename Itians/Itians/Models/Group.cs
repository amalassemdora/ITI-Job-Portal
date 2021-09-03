using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupAdmins = new HashSet<GroupAdmin>();
            GroupUsers = new HashSet<GroupUser>();
            Posts = new HashSet<Post>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public string GroupCover { get; set; }

        public virtual ICollection<GroupAdmin> GroupAdmins { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
