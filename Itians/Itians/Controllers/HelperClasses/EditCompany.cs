using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public class EditCompany
    {
        public int CompanyId { get; set; }
        public string CompanyUsername { get; set; }
        public string Description { get; set; }
        public DateTime EstablishDate { get; set; }
        public string WebsiteUrl { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Cover { get; set; }
        public string HiddenImage { get; set; }
        public string HiddenCover { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
