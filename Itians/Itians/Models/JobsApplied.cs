using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class JobsApplied
    {
        public int IdJob { get; set; }
        public int UserId { get; set; }
        public DateTime AppliedDate { get; set; }

        public virtual JobPost IdJobNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
