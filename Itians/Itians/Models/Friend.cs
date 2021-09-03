using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Friend
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public int RelationId { get; set; }

        public virtual UserRelation Relation { get; set; }
        public virtual User UserId1Navigation { get; set; }
        public virtual User UserId2Navigation { get; set; }
    }
}
