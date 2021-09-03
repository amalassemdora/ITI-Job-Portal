using Itians.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public class EditUsers
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FormalEmail { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public IFormFile Cv { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Cover { get; set; }
        public string HiddenCv { get; set; }
        public string HiddenImage { get; set; }
        public string HiddenCover { get; set; }
        public double? CurrrentSalary { get; set; }
        public bool IsYearlyMonthly { get; set; }
        public string AboutMe { get; set; }
        public string Currency { get; set; }

        public string CompanyName { get; set; }
        public string LocationCity { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int ExperienceId { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }


        public string CertificateDegree { get; set; }
        public string Major { get; set; }
        public string Universty { get; set; }
        public double? Percentage { get; set; }
        public double? Gpa { get; set; }
        public int EducationId { get; set; }

    }
}
