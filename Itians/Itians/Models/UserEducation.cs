using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserEducation
    {
        public int UserId { get; set; }
        public string CertificateDegree { get; set; }
        public string Major { get; set; }
        public string Universty { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public double? Percentage { get; set; }
        public double? Gpa { get; set; }
        public int EducationId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
