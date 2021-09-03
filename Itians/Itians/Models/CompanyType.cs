using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            Companies = new HashSet<Company>();
        }

        public int CompanyTypeId { get; set; }
        public string CompanyTyppe { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
