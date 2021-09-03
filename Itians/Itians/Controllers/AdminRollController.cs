using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]
	public class AdminRollController : Controller
	{
		itiansContext db;
		public AdminRollController(itiansContext db)
		{
			this.db = db;
		}
		
		public IActionResult Index()
		{
			var Role = db.Users.Include(d => d.Role).ToList();
			ViewBag.Role = Role;
			return View();
		}
		
		public IActionResult edit(int id)
		{
			User U = db.Users.Where(o => o.UserId == id).SingleOrDefault();
			SelectList g = new SelectList(db.UserRoles.ToList(), "RoleId", "RoleName");
			ViewBag.Role = g;
			return View(U);
		}
		[HttpPost]
		public IActionResult edit(User U)
		{
			if (U.License == null)
			{
				U.License = db.Users.Where(o => o.UserId == U.UserId).Select(o => o.License).SingleOrDefault();
			}
			db.Entry(U).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
