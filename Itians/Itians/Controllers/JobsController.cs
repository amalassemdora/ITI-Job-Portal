using Itians.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Itians.Controllers
{
    
    public class JobsController : Controller
    {
        private readonly itiansContext _db;

        public JobsController(itiansContext db)
        {
            _db = db;
        }
        ///Jobs/ShowAllJobs
        public IActionResult ShowAllJobs()
        {
            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            int iduser = int.Parse(idClaim.Value);
            var jobs = _db.JobPosts.Include(c => c.Company).Include(c => c.JobType).Include(x=>x.JobsSaveds).ToList();
            if (jobs == null)
            {
                return NotFound();
            }
            ViewBag.jobs = jobs;
            return View();
        }
     
        public  IActionResult savejob(int id)
        {

            Claim idClaim = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            int iduser = int.Parse(idClaim.Value);
            
            JobsSaved newjob = new JobsSaved
            {
               IdJob=id,
               UserId=iduser
            };
            _db.JobsSaveds.Add(newjob);
            _db.SaveChanges();
            return RedirectToAction("ShowAllJobs");
        }


    }
}
