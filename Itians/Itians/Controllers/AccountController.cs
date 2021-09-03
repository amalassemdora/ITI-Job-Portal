using Itians.Controllers.HelperClasses;
using Itians.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Itians.Controllers
{
    public class AccountController : Controller
    {
        itiansContext db;
        IHostingEnvironment hostingEnvironment;
        public AccountController(itiansContext db , IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("4"))
                {
                    return LocalRedirect("/Companies/Details/"+User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier).Value);
                }
                return LocalRedirect("/");
            }
                
            return View(new LoginModel { returnUrl = ReturnUrl });
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("4"))
                {
                    return LocalRedirect("/Companies/Details/" + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
                return LocalRedirect("/");
            }
            dynamic user;
            if (model.loginType == "itian")
            { // Itian User 
                user = db.Users.Where(u => u.Email == model.email && u.Password == model.password.Sha256()).SingleOrDefault();
            }
            else
            { // Company User
                user = db.Companies.Where(u => u.Email == model.email && u.Password == model.password.Sha256()).SingleOrDefault();
            }
            if (user == null)
            {
                ViewBag.status = true;
                return View();
            }
            if (user.IsApproved) {
                int groupId = 0;
                if (model.loginType == "itian"){
                    int userId = user.UserId;
                    groupId = db.GroupUsers.FirstOrDefault(gu => gu.UserId == userId).GroupId;
                } 
                var claims = new List<Claim>()
             {
                new Claim(ClaimTypes.NameIdentifier , (model.loginType=="itian") ? user.UserId.ToString() : user.CompanyId.ToString()),
                new Claim(ClaimTypes.Role , user.RoleId.ToString()),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.GroupSid , groupId.ToString()),
                new Claim(ClaimTypes.Actor , (user.Image==null)?"profile.jpg":user.Image)
             };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = model.rememberMe
                        });
                if (User.IsInRole("4"))
                {
                    return LocalRedirect("/Companies/Details/" + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
                //retuen url
                return LocalRedirect("/");
            }
            if (model.loginType == "company")
            {
                Company companAuth = db.Companies.SingleOrDefault(c => c.Email == model.email);
                ViewBag.company = companAuth;
            }
            else
            {
                User userAuth = db.Users.SingleOrDefault(c => c.Email == model.email);
                ViewBag.user = userAuth;
            }
            return View("WaitingPage");
        }
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        [AllowAnonymous]
        public  IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("4"))
                {
                    return LocalRedirect("/Companies/Details/" + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
                return LocalRedirect("/User/Profile/");
            }
            
            var group = db.Groups.ToList();
            ViewBag.group = group;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("4"))
                {
                    return LocalRedirect("/Companies/Details/" + User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
                return LocalRedirect("/User/Profile/");
            }

            if (ModelState.IsValid)
            {
                if (model.registerType == "itian")
                {
                    // Upload License File
                    string uploadFile = Path.Combine(hostingEnvironment.WebRootPath, "Attachments/Licenses");
                    string uniqueFileName = model.userName.Replace(".","") + "_License." + model.license.FileName.Split(".").Last();
                    string filePath = Path.Combine(uploadFile, uniqueFileName);
                    model.license.CopyTo(new FileStream(filePath, FileMode.Create));
                    User user = new User
                    {
                        Username = model.userName,
                        Email = model.email,
                        Password = model.password.Sha256(),
                        BirthDate = model.birthDateOrEstablishDate,
                        Gender = model.gender,
                        License = uniqueFileName,
                        NationalId = model.nationalId,
                        RoleId = 2
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    int userId = db.Users.FirstOrDefault(u => u.Email == model.email).UserId;
                    UserProfile userProfile = new UserProfile { UserId=userId};
                    GroupUser groupUser = new GroupUser { UserId=userId , GroupId=model.groupTypeId};
                    db.UserProfiles.Add(userProfile);
                    db.GroupUsers.Add(groupUser);
                    db.SaveChanges();
                }
                else if (model.registerType == "company")
                {
                    // Upload License File
                    string uploadFile = Path.Combine(hostingEnvironment.WebRootPath, "Attachments/Licenses");
                    //string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.license.FileName;
                    string uniqueFileName = model.companyUserName.Replace(".", "") + "_License." + model.license.FileName.Split(".").Last();
                    string filePath = Path.Combine(uploadFile, uniqueFileName);
                    model.license.CopyTo(new FileStream(filePath, FileMode.Create));
                    Company company = new Company
                    {
                        CompanyUsername = model.companyUserName,
                        Email = model.companyEmail,
                        Password = model.password.Sha256(),
                        EstablishDate = model.birthDateOrEstablishDate,
                        WebsiteUrl = model.companyWebSite,
                        License = uniqueFileName,
                        RoleId = 4,
                        CompanyTypeId = int.Parse(model.companyTypeId)

                    };
                    db.Companies.Add(company);
                    db.SaveChanges();
                    //return LocalRedirect("/EditCompanyController/ShowEditCompany");
                }
                return LocalRedirect("/Account/Login");
            }
            return View(); 
        }

        // Check unique values from Database
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUserName(string userName)
        {
            User user = db.Users.Where(user => user.Username == userName).FirstOrDefault();
            if (user == null)
                return Json(true);
            else
                return Json($"UserName: {userName} is taken");
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUserEmail(string email)
        {
            User user = db.Users.Where(user => user.Email == email).FirstOrDefault();
            if (user == null)
                return Json(true);
            else
                return Json($"Email {email} is already in use");
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckCompanyUserName(string userName)
        {
            Company com = db.Companies.Where(com => com.CompanyUsername == userName).FirstOrDefault();
            if (com == null)
                return Json(true);
            else
                return Json(false);
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckCompanyEmail(string email)
        {
            Company com = db.Companies.Where(com => com.Email == email).FirstOrDefault();
            if (com == null)
                return Json(true);
            else
                return Json(false);
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckNationalId(string nationalId)
        {
            User user = db.Users.Where(user => user.NationalId == nationalId).FirstOrDefault();
            if (user == null)
                return Json(true);
            else
                return Json($"NID: {nationalId} is already taken");
        }
        [AllowAnonymous]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (regex.IsMatch(password))
                return Json(true);
            else
                return Json("Password must contain at least 8 characters, including UPPER/lower case and numbers");
        }

        
    }
}
