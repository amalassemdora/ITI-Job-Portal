using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserExperience
    {
        public int UserId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string CompanyName { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string LocationCountry { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int ExperienceId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
