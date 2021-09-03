using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]
	public class AdminApproveUserController : Controller
	{
		itiansContext db;
		public AdminApproveUserController(itiansContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			
			var Users = db.Users.ToList();
			ViewBag.Users = Users;
			return View();
		}
		public IActionResult details(int id)
		{
			User U = db.Users.Where(o => o.UserId == id).SingleOrDefault();
			return View(U);
		}
		[HttpPost]
		public IActionResult details(User U)
		{
		
			if (U.License == null)
			{
				U.License = db.Users.Where(o=>o.UserId==U.UserId).Select(o => o.License).SingleOrDefault();
			}
			db.Entry(U).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
