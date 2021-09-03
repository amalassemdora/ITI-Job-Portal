using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class JobType
    {
        public JobType()
        {
            JobPosts = new HashSet<JobPost>();
        }

        public int JobTypeId { get; set; }
        public string JobType1 { get; set; }

        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}
