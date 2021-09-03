using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class JobsSaved
    {
        public int IdJob { get; set; }
        public int UserId { get; set; }
        public DateTime SavedDate { get; set; }

        public virtual JobPost IdJobNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
