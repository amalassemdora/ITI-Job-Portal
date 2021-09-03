using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class CompanyLocation
    {
        public int CompanyLocationId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
