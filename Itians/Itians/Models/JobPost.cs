using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class JobPost
    {
        public JobPost()
        {
            JobsApplieds = new HashSet<JobsApplied>();
            JobsSaveds = new HashSet<JobsSaved>();
        }

        public int IdJob { get; set; }
        public int CompanyId { get; set; }
        public DateTime? CreatedData { get; set; }
        public string JobDesc { get; set; }
        public bool IsActive { get; set; }
        public int JobTypeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Counrty { get; set; }
        public string Zip { get; set; }
        public string Title { get; set; }

        public virtual Company Company { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual ICollection<JobsApplied> JobsApplieds { get; set; }
        public virtual ICollection<JobsSaved> JobsSaveds { get; set; }
    }
}
