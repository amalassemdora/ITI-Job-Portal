using Itians.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Itians.Models;
using Itians.Controllers.HelperClasses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Itians.Controllers
{

    public class EditCompanyController : Controller
    {
        itiansContext db;
        IHostingEnvironment hostingEnvironment;
        public EditCompanyController(itiansContext db, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
  
        public IActionResult ShowEditCompany()
        {
            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            int id = int.Parse(idClaim.Value);
            var company = db.Companies
                .Include(Company => Company.CompanyType)
                .FirstOrDefault(user => user.CompanyId == id);
         
            ViewBag.company = company;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveContact(EditCompany ReceivedCompany)
        {
            
                SaveFile("Cover", ReceivedCompany.Cover, ReceivedCompany.CompanyUsername, out string CoverFileName);
                SaveFile("Image", ReceivedCompany.Image, ReceivedCompany.CompanyUsername, out string ImageFileName);
                Company company = new Company
                {
                    CompanyId = ReceivedCompany.CompanyId,
                    Email = ReceivedCompany.Email,
                    WebsiteUrl = ReceivedCompany.WebsiteUrl,
                    Adress = ReceivedCompany.Adress,
                    Image = ReceivedCompany.Image == null ? ReceivedCompany.HiddenImage : ImageFileName,
                    Cover = ReceivedCompany.Cover == null ? ReceivedCompany.HiddenCover : CoverFileName
                };
                db.Entry(company).State = EntityState.Modified;
                db.Entry(company).Property(x => x.CompanyUsername).IsModified = false;
                db.Entry(company).Property(x => x.Description).IsModified = false;
                db.Entry(company).Property(x => x.EstablishDate).IsModified = false;
                db.Entry(company).Property(x => x.CompanyTypeId).IsModified = false;
                db.Entry(company).Property(x => x.License).IsModified = false;
                db.Entry(company).Property(x => x.Password).IsModified = false;
                db.Entry(company).Property(x => x.RoleId).IsModified = false;
                db.Entry(company).Property(x => x.IsApproved).IsModified = false;
                db.Entry(company).Property(x => x.CommentFromAdmin).IsModified = false;
            await db.SaveChangesAsync();
            return RedirectToAction("ShowEditCompany");
        }
        public async Task<IActionResult> SaveAboutUs(EditCompany ReceivedCompany)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company
                {
                    CompanyId = ReceivedCompany.CompanyId,
                    Description=ReceivedCompany.Description,
                    EstablishDate=ReceivedCompany.EstablishDate
                };
                db.Entry(company).State = EntityState.Modified;
                db.Entry(company).Property(x => x.Adress).IsModified = false;
                db.Entry(company).Property(x => x.Image).IsModified = false;
                db.Entry(company).Property(x => x.Cover).IsModified = false;
                db.Entry(company).Property(x => x.CompanyUsername).IsModified = false;
                db.Entry(company).Property(x => x.Email).IsModified = false;
                db.Entry(company).Property(x => x.WebsiteUrl).IsModified = false;
                db.Entry(company).Property(x => x.CompanyTypeId).IsModified = false;
                db.Entry(company).Property(x => x.License).IsModified = false;
                db.Entry(company).Property(x => x.Password).IsModified = false;
                db.Entry(company).Property(x => x.RoleId).IsModified = false;
                db.Entry(company).Property(x => x.IsApproved).IsModified = false;
                db.Entry(company).Property(x => x.CommentFromAdmin).IsModified = false;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("ShowEditCompany");
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

    }
}
