using Microsoft.AspNetCore.Mvc;
using Itians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Itians.Controllers
{
    public class UserController : Controller
    {
        itiansContext db;
        IHostingEnvironment hostingEnvironment;
        public UserController(itiansContext db, IHostingEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Profile(int id)
        {
            // Check Inciming Id if equal 0 get current user id
            if (id == 0)
            {
                id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            var user = db.Users
                .Include(user => user.UserProfile)
                    .ThenInclude(profile => profile.UserEducations)
                .Include(user => user.UserProfile)
                    .ThenInclude(profile => profile.UserExperiences)
                .Include(user => user.UserProfile)
                    .ThenInclude(profile => profile.UserSkills)
                .FirstOrDefault(user => user.UserId == id);
            ViewBag.user = user;
            return View();

            //var user = db.Users
            //    .Include(user => user.UserProfile)
            //        .ThenInclude(profile => profile.UserEducations)
            //    .Include(user => user.UserProfile)
            //        .ThenInclude(profile => profile.UserExperiences)
            //    .Include(user => user.UserProfile)
            //        .ThenInclude(profile => profile.UserSkills)
            //    .Include(user => user.Posts)
            //        .ThenInclude(post => post.PostLikes)
            //    .Include(user => user.Posts.OrderByDescending(post => post.CreatedAt))
            //        .ThenInclude(post => post.Comments)
            //            .ThenInclude(comment => comment.User)
            //        .Include(comment => comment.CommentLikes)
            //    .FirstOrDefault(user => user.UserId == id);
        }
        public IActionResult AddPost(string authorId , string body)
        {
            Post post = new Post()
            {
                Body = body,
                AuthorId = int.Parse(authorId),
            };
            db.Posts.Add(post);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult LoadPost(string id)
        {
            // Form Current user to make comment image change and comment author
            int visitedId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            ViewBag.visitedUser = db.Users.FirstOrDefault(u => u.UserId == visitedId);

            int authorId = int.Parse(id);
            var user = db.Users.Single(u => u.UserId == authorId);
            var posts = db.Entry(user)
                .Collection(u => u.Posts)
                .Query()
                .OrderByDescending(p => p.CreatedAt)
                .Include(p => p.Comments.OrderByDescending(c => c.CreatedAt))
                    .ThenInclude(c => c.User);

            ViewBag.userPosts = posts;
            return PartialView();
        }

        public IActionResult AddComment(string postId, string authorId, string body)
        {
            Comment comment = new Comment()
            {
                PostId = int.Parse(postId),
                UserId = int.Parse(authorId),
                Body = body,
            };
            db.Comments.Add(comment);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult LoadComment(string id)
        {
            int postId = int.Parse(id);

            var comments = db.Comments.OrderByDescending(c=>c.CreatedAt)
                .Include(c => c.User)
                .Where(c => c.PostId == postId ).ToList();
            ViewBag.comments = comments;
            return PartialView();
        }

        public IActionResult DeletePost(string id)
        {
            int postId = int.Parse(id);
            Post post = db.Posts.FirstOrDefault(p=>p.PostId==postId);
            db.Posts.Remove(post);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult EditPost(string id , string body)
        {
            int postId = int.Parse(id);
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);
            post.Body = body;
            db.Entry(post).State = EntityState.Modified;
            db.Entry(post).Property(x => x.CreatedAt).IsModified = false;
            db.SaveChanges();
            return Json(true);
        }
        public IActionResult DeleteComment(string id)
        {
            int commentId = int.Parse(id);
            Comment comment = db.Comments.FirstOrDefault(c => c.CommentId == commentId);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Json(true);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult Search(string searchStr)
        {
            // Search in Users Profiles
            dynamic user = db.Users.FirstOrDefault(u => u.Username == searchStr);
            if (user == null)
            {
                // Search in Companies Profiles
                user = db.Companies.FirstOrDefault(c => c.CompanyUsername == searchStr);
                if (user != null)
                {
                    int companyId = user.CompanyId;
                    return LocalRedirect("/Companies/Details/" +companyId);
                }
                return NotFound();
            }
            int id = user.UserId;
            return LocalRedirect("/User/Profile/"+id);
        }

        public IActionResult DownloadCv(string id)
        {
            try
            {
            // get the path of the file
            string path = Path.Combine(hostingEnvironment.WebRootPath, "Attachments/Cvs/" + id);
            // convert it to a stream
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            // Return the file. A byte array can also be used instead of a stream
            return File(bytes, "application/octet-stream", id);
            //return File($"~/Attachments/Cvs/"+fileName);
            }
            catch 
            {
                return Json("file is used");
            }
        }
    }
}
