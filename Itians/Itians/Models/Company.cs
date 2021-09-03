using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyLocations = new HashSet<CompanyLocation>();
            JobPosts = new HashSet<JobPost>();
        }

        public int CompanyId { get; set; }
        public string CompanyUsername { get; set; }
        public string Description { get; set; }
        public DateTime EstablishDate { get; set; }
        public string WebsiteUrl { get; set; }
        public string Image { get; set; }
        public int CompanyTypeId { get; set; }
        public string License { get; set; }
        public string Cover { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsApproved { get; set; }
        public string CommentFromAdmin { get; set; }
        public string Adress { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual ICollection<CompanyLocation> CompanyLocations { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}
