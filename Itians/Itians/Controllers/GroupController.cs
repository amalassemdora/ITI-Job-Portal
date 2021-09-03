using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itians.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Itians.Controllers
{
    public class GroupController : Controller
    {
        itiansContext db;
        public GroupController(itiansContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int id=1)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = db.Users
                .Include(u => u.GroupUsers).Single(u => u.UserId == userId);

            if (user.GroupUsers.FirstOrDefault(g => g.GroupId == id) == null)
            {
                return Unauthorized();
            }
            ViewBag.groupId = id;
            ViewBag.groupName = db.Groups.FirstOrDefault(g => g.GroupId == id).GroupName;
            return View();
        }

        public IActionResult Member(int id=1)
        {
            var members = db.GroupUsers
                .Include(gu => gu.User)
                .Where(gu => gu.GroupId == id).ToList();

            ViewBag.groupId = id;
            ViewBag.groupMembers = members;
            return View();
        }

        public IActionResult LoadPost(string id)
        {
            int groupId = int.Parse(id);
            var posts = db.Posts.OrderByDescending(p => p.CreatedAt)
                .Include(p => p.Author)
                .Include(p => p.Comments.OrderByDescending(c => c.CreatedAt))
                    .ThenInclude(c => c.User)
                .Where(p => p.GroupId == groupId).ToList();

            ViewBag.groupPosts = posts;
            return PartialView();
        }

        public IActionResult AddPost(string groupId , string authorId , string body)
        {
            Post post = new Post()
            {
                GroupId = int.Parse(groupId),
                AuthorId = int.Parse(authorId),
                Body = body ,
            };
            db.Posts.Add(post);
            db.SaveChanges();

            return Json(true);
        }

        public IActionResult LoadComment(string id)
        {
            int postId = int.Parse(id);
            var comments = db.Comments.OrderByDescending(c => c.CreatedAt)
                .Include(c => c.User)
                .Where(p => p.PostId == postId).ToList();

            ViewBag.postComments = comments;
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

        public IActionResult DeletePost(string id)
        {
            int postId = int.Parse(id);
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);
            db.Posts.Remove(post);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult EditPost(string id, string body)
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


    }
}
