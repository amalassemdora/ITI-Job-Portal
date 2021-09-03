using Itians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public class CompanyModel
    {
        public CompanyModel()
        {
            JobPosts = new HashSet<JobPost>();
            companyLocation = new HashSet<CompanyLocation>();
        }
       
        //for Cmpany

        public Company company { get; set; }
        

        // for job

        public ICollection<JobPost> JobPosts { get; set; }


        public ICollection<CompanyLocation> companyLocation { get; set; }




    }
}
