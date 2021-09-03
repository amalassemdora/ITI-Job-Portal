using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public class RegisterModel
    {
        public string registerType { get; set; }
        // For User
        [Remote(action: "CheckUserName", controller:"Account")]
        public string userName { get; set; }
        [Remote(action: "CheckUserEmail", controller: "Account")]
        public string email { get; set; }
        [Remote(action:"CheckPassword",controller:"Account")]
        public string password { get; set; }
        [Compare("password" , ErrorMessage ="Password doesn't match")]
        public string confirmPassword { get; set; }
        [Remote(action: "CheckNationalId", controller: "Account")]
        public string nationalId { get; set; }
        public DateTime birthDateOrEstablishDate { get; set; }
        public string gender { get; set; }
        public int groupTypeId { get; set; }
        [Required(ErrorMessage ="Enter Your License Please")]
        public IFormFile license { get; set; }
        // For Company
        [Remote(action: "CheckCompanyUserName", controller: "Account")]
        public string companyUserName { get; set; }
        [Remote(action: "CheckCompanyEmail", controller: "Account")]
        public string companyEmail { get; set; }
        public string companyWebSite { get; set; }
        public string companyTypeId { get; set; }
    }
}
