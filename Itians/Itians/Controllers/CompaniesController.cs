using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Itians.Models;
using Itians.Controllers.HelperClasses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Itians.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly itiansContext _context;

        public CompaniesController(itiansContext context)
        {
            _context = context;
        }
        // GET: Companies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var company =  _context.Companies
                .Include(c => c.CompanyType)
                .Include(c => c.JobPosts)
                    .ThenInclude(c=>c.JobType)
                .FirstOrDefault(m => m.CompanyId == id);
            var jobtype = _context.JobTypes.ToList();
            
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            ViewBag.company = company;
            ViewBag.jobtype = jobtype;
            return View();
        }
        public IActionResult jobPost(string id)
        {
            string[] data = id.Split("~~");
            int authorId = int.Parse(data[0]);
            if (data.Length > 1)
            {
                JobPost jobPost = new JobPost()
                {
                    CompanyId = int.Parse(data[0]),
                    JobDesc = data[1],
                    Title = data[2],
                    JobTypeId = int.Parse(data[3]),
                    Street = data[4],
                    City = data[5],
                    State = data[6],
                    Counrty = data[7],
                    Zip = data[8],
                };
                _context.JobPosts.Add(jobPost);
                _context.SaveChanges();
            }
            var company1 = _context.Companies.Single(u => u.CompanyId == authorId);
            var jobposts = _context.Entry(company1)
                .Collection(u => u.JobPosts)
                .Query()
                .OrderByDescending(p => p.CreatedData)
                .Include(p => p.JobType);

            ViewBag.jobPosts = jobposts;

            return PartialView();
        }

    }
}
