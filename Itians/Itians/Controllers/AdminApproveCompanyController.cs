using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]

	public class AdminApproveCompanyController : Controller
	{
		itiansContext db;
		public AdminApproveCompanyController(itiansContext db)
		{
			this.db = db;
		}
		
		public IActionResult Index()
		{
			var company = db.Companies.ToList();
			ViewBag.company = company;
			return View();
		}

		
		public IActionResult details(int id)
		{
			Company c = db.Companies.Where(o => o.CompanyId == id).SingleOrDefault();
			
			return View(c);
		}
		[HttpPost]
		
		public IActionResult details(Company C)
		{ 
			if (C.License == null)
			{
				C.License = db.Companies.Where(o=>o.CompanyId == C.CompanyId).Select(o => o.License).SingleOrDefault();
			}
			db.Entry(C).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
         }
	}
}
