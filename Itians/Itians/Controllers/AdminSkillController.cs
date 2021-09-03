using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.EntityFrameworkCore;

namespace Itians.Controllers
{
	[Authorize(Roles = "1")]
	public class AdminSkillController : Controller
	{
		itiansContext db;
		public AdminSkillController(itiansContext db)
		{
			this.db = db;
		}
		
		public IActionResult Index()
		{
			var skills = db.Skills.ToList();
			ViewBag.skills = skills;
			return View();
		}
		
		public IActionResult edit(int id)
		{
			Skill s = db.Skills.Where(n => n.SkillId == id).SingleOrDefault();
			return View(s);
		}
		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult edit(Skill s)
		{
			db.Entry(s).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
			
		}
		
		public IActionResult add()
		{
			return View();
		}
		[HttpPost]
		
		public IActionResult add(Skill s)
		{
			if (ModelState.IsValid) {
				db.Skills.Add(s);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
		
		public IActionResult delete(int id)
		{
			Skill s = db.Skills.Where(o => o.SkillId == id).SingleOrDefault();
			db.Remove(s);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
