using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]
	public class AdminGroupController : Controller
	{
		itiansContext db;
		public AdminGroupController(itiansContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			var group = db.Groups.ToList();
			ViewBag.group = group;
			return View();
		}
		public IActionResult edit(int id)
		{
			Group G = db.Groups.Where(o => o.GroupId == id).SingleOrDefault();
			SelectList U = new SelectList(db.Users.ToList(), "UserId", "Username ");
			ViewBag.user = U;
			return View(G);
		}
		[HttpPost]
		public IActionResult edit(Group G)
		{
			db.Entry(G).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");

		}
		public IActionResult add()
		{
				SelectList U = new SelectList(db.Users.ToList(), "UserId", "Username ");
				ViewBag.user = U;
			
			return View();
		}
		[HttpPost]
		public IActionResult add(Group G)
		{
			db.Entry(G).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
