using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserRelation
    {
        public UserRelation()
        {
            Friends = new HashSet<Friend>();
        }

        public int RelationId { get; set; }
        public string RelationName { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }
    }
}
