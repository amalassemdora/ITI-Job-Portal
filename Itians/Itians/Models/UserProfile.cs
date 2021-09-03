using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserEducations = new HashSet<UserEducation>();
            UserExperiences = new HashSet<UserExperience>();
            UserSkills = new HashSet<UserSkill>();
        }

        public int UserId { get; set; }
        public double? CurrrentSalary { get; set; }
        public bool? IsYearlyMonthly { get; set; }
        public string Currency { get; set; }
        public string FormalEmail { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string AboutMe { get; set; }
        public string Cv { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserEducation> UserEducations { get; set; }
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
