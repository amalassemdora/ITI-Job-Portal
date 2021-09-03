using Itians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
	public class GroupModel
	{
        public GroupModel()
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
