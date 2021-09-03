using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]
	public class AdminJobController : Controller
	{
		itiansContext db;
		public AdminJobController(itiansContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			
			var Job = db.JobTypes.ToList();
			ViewBag.Job = Job;
			return View();
		}
		
		public IActionResult edit(int id)
		{
			JobType J = db.JobTypes.Where(n => n.JobTypeId == id).SingleOrDefault();
			return View(J);
		}
		
		[HttpPost]
		public IActionResult edit(JobType J)
		{
			db.Entry(J).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");

		}
		
		public IActionResult add()
		{
			return View();
		}
		[HttpPost]
		
		public IActionResult add(JobType J)
		{
			db.JobTypes.Add(J);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public IActionResult delete(int id)
		{
			JobType J = db.JobTypes.Where(o => o.JobTypeId == id).SingleOrDefault();
			db.Remove(J);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
