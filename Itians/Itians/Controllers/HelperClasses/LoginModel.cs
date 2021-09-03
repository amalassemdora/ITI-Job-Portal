using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public enum LoginType
    {
        Itian,
        Company
    }
    public class LoginModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public bool rememberMe { get; set; }
        public string loginType { get; set; }
        public string returnUrl { get; set; }

    }
}
