using Itians.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using Itians.Models;
using System.Threading.Tasks;
using Itians.Controllers.HelperClasses;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Itians.Controllers
{
    public class EditProfileController : Controller
    {
        itiansContext db;
        IHostingEnvironment hostingEnvironment;
        public EditProfileController(itiansContext db, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult EditProfile()
        {
            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            int id = int.Parse(idClaim.Value);
            var user = db.Users
                .Include(user => user.UserProfile)
                .FirstOrDefault(user => user.UserId == id);
            var userEducationSkills = db.UserProfiles
                    .Include(profile => profile.UserEducations)
                    .Include(profile => profile.UserSkills)
                    .FirstOrDefault(user => user.UserId == id);
            var UserExperience = db.UserExperiences.ToList().OrderByDescending(x => x.StartingDate).FirstOrDefault(user => user.UserId == id);
            var userEducation = db.UserEducations.ToList().OrderByDescending(x => x.StartingDate).FirstOrDefault(user => user.UserId == id);


            if (user != null)
                ViewBag.user = user;
            if (userEducation != null)
                ViewBag.userEducation = userEducation;
            if (UserExperience != null)
                ViewBag.UserExperience = UserExperience;

            return View();
        }
        public void SaveFile(string file, IFormFile formFile, string username, out string filename)
        {
            if (formFile != null)
            {

                string uploadFile = Path.Combine(hostingEnvironment.WebRootPath, $"Attachments/{file}s");
                filename = username.Replace(".", "") + $"_{file}." + formFile.FileName.Split(".").Last();
                string filePath = Path.Combine(uploadFile, filename);
                formFile.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            else
            {
                filename = "";
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveContact(EditUsers ReceivedUser)
        {
            if (ModelState.IsValid)
            {
                SaveFile("Image", ReceivedUser.Image, ReceivedUser.Username, out string ImageFileName);
                SaveFile("Cover", ReceivedUser.Cover, ReceivedUser.Username, out string CoverFileName);
                SaveFile("Cv", ReceivedUser.Cv, ReceivedUser.Username, out string CvFileName);

                User user = new User
                {
                    UserId = ReceivedUser.UserId,
                    Image = ReceivedUser.Image == null ? ReceivedUser.HiddenImage : ImageFileName,
                    Cover = ReceivedUser.Cover == null ? ReceivedUser.HiddenCover : CoverFileName
                };
                db.Entry(user).State = EntityState.Modified;
                UserProfile userprofile = new UserProfile
                {
                    UserId = ReceivedUser.UserId,
                    FormalEmail = ReceivedUser.FormalEmail,
                    Linkedin = ReceivedUser.Linkedin,
                    Github = ReceivedUser.Github,
                    Cv = ReceivedUser.Cv == null ? ReceivedUser.HiddenCv : CvFileName
                };
                db.Entry(user).State = EntityState.Modified;
                db.Entry(userprofile).State = EntityState.Modified;
                db.Entry(user).Property(x => x.Email).IsModified = false;
                db.Entry(user).Property(x => x.Gender).IsModified = false;
                db.Entry(user).Property(x => x.Password).IsModified = false;
                db.Entry(user).Property(x => x.License).IsModified = false;
                db.Entry(user).Property(x => x.RoleId).IsModified = false;
                db.Entry(user).Property(x => x.NationalId).IsModified = false;
                db.Entry(user).Property(x => x.BirthDate).IsModified = false;
                db.Entry(user).Property(x => x.IsApproved).IsModified = false;
                db.Entry(user).Property(x => x.Username).IsModified = false;
                db.Entry(userprofile).Property(x => x.AboutMe).IsModified = false;
                db.Entry(userprofile).Property(x => x.CurrrentSalary).IsModified = false;
                db.Entry(userprofile).Property(x => x.IsYearlyMonthly).IsModified = false;
                db.Entry(userprofile).Property(x => x.Currency).IsModified = false;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("EditProfile");
        }
        [HttpPost]
        public async Task<IActionResult> SaveAboutme(EditUsers ReceivedUser)
        {
            if (ModelState.IsValid)
            {
                UserProfile userprofile = new UserProfile
                {
                    UserId = ReceivedUser.UserId,
                    AboutMe = ReceivedUser.AboutMe,
                    CurrrentSalary = ReceivedUser.CurrrentSalary,
                    IsYearlyMonthly = ReceivedUser.IsYearlyMonthly,
                    Currency = ReceivedUser.Currency,
                };
                db.Entry(userprofile).State = EntityState.Modified;
                db.Entry(userprofile).Property(x => x.FormalEmail).IsModified = false;
                db.Entry(userprofile).Property(x => x.Linkedin).IsModified = false;
                db.Entry(userprofile).Property(x => x.Github).IsModified = false;
                db.Entry(userprofile).Property(x => x.Cv).IsModified = false;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("EditProfile");
        }
        [HttpPost]
        public async Task<IActionResult> SaveExperience(EditUsers ReceivedUser)
        {
            if (ModelState.IsValid)
            {
                UserExperience userExperience = new UserExperience
                {

                    UserId = ReceivedUser.UserId,
                    ExperienceId = ReceivedUser.ExperienceId,
                    CompanyName = ReceivedUser.CompanyName,
                    LocationCity = ReceivedUser.LocationCity,
                    Description = ReceivedUser.Description,
                    Position = ReceivedUser.Position,
                    StartingDate = ReceivedUser.StartingDate,
                    EndingDate = ReceivedUser.EndingDate
                };
                db.Entry(userExperience).State = EntityState.Modified;
                db.Entry(userExperience).Property(x => x.LocationCountry).IsModified = false;
                db.Entry(userExperience).Property(x => x.LocationState).IsModified = false;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("EditProfile");
        }
        public IActionResult AddExperience()
        {
            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (int.Parse(idClaim.Value) > 0)
                ViewBag.id = int.Parse(idClaim.Value);
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(EditUsers ReceivedUser)
        {

            UserExperience userExperience = new UserExperience
            {

                UserId = ReceivedUser.UserId,
                CompanyName = ReceivedUser.CompanyName,
                LocationCity = ReceivedUser.LocationCity,
                Description = ReceivedUser.Description,
                Position = ReceivedUser.Position,
                StartingDate = ReceivedUser.StartingDate,
                EndingDate = ReceivedUser.EndingDate,
                LocationState = "",
                LocationCountry = ""
            };
            db.UserExperiences.Add(userExperience);
            db.SaveChanges();
            return RedirectToAction("EditProfile");
        }
        public IActionResult DeleteExperience(EditUsers ReceivedUser)
        {

            var userExperience = db.UserExperiences.Where(n => n.ExperienceId == ReceivedUser.ExperienceId).SingleOrDefault();
            db.UserExperiences.Remove(userExperience);
            db.SaveChanges();
            return RedirectToAction("EditProfile");
        }
        public async Task<IActionResult> SaveEducation(EditUsers ReceivedUser)
        {
            if (ModelState.IsValid)
            {
                UserEducation userEducation = new UserEducation
                {

                    EducationId = ReceivedUser.EducationId,
                    UserId = ReceivedUser.UserId,
                    CertificateDegree = ReceivedUser.CertificateDegree,
                    Major = ReceivedUser.Major,
                    Universty = ReceivedUser.Universty,
                    Percentage = ReceivedUser.Percentage,
                    Gpa = ReceivedUser.Gpa,
                    StartingDate = ReceivedUser.StartingDate,
                    EndingDate = ReceivedUser.EndingDate
                };
                db.Entry(userEducation).State = EntityState.Modified;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("EditProfile");
        }
        public IActionResult AddEducation()
        {
            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (int.Parse(idClaim.Value) > 0)
                ViewBag.id = int.Parse(idClaim.Value);
            return View();
        }
        [HttpPost]
        public IActionResult AddEducation(EditUsers ReceivedUser)
        {

            UserEducation userEducation = new UserEducation
            {

                EducationId = ReceivedUser.EducationId,
                UserId = ReceivedUser.UserId,
                CertificateDegree = ReceivedUser.CertificateDegree,
                Major = ReceivedUser.Major,
                Universty = ReceivedUser.Universty,
                Percentage = ReceivedUser.Percentage,
                Gpa = ReceivedUser.Gpa,
                StartingDate = ReceivedUser.StartingDate,
                EndingDate = ReceivedUser.EndingDate
            };
            db.UserEducations.Add(userEducation);
            db.SaveChanges();
            return RedirectToAction("EditProfile");
        }
        public IActionResult DeleteEducation(EditUsers ReceivedUser)
        {

            var userEducation = db.UserEducations.Where(n => n.EducationId == ReceivedUser.EducationId).SingleOrDefault();
            db.UserEducations.Remove(userEducation);
            db.SaveChanges();
            return RedirectToAction("EditProfile");
        }

    }
}