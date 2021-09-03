using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class User
    {
        public User()
        {
            CommentLikes = new HashSet<CommentLike>();
            Comments = new HashSet<Comment>();
            FriendUserId1Navigations = new HashSet<Friend>();
            FriendUserId2Navigations = new HashSet<Friend>();
            GroupAdmins = new HashSet<GroupAdmin>();
            GroupUsers = new HashSet<GroupUser>();
            JobsApplieds = new HashSet<JobsApplied>();
            JobsSaveds = new HashSet<JobsSaved>();
            PostLikes = new HashSet<PostLike>();
            Posts = new HashSet<Post>();
            ReplyLikes = new HashSet<ReplyLike>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string Image { get; set; }
        public string License { get; set; }
        public int RoleId { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cover { get; set; }
        public bool IsApproved { get; set; }
        public string CommentFromAdmin { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Friend> FriendUserId1Navigations { get; set; }
        public virtual ICollection<Friend> FriendUserId2Navigations { get; set; }
        public virtual ICollection<GroupAdmin> GroupAdmins { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<JobsApplied> JobsApplieds { get; set; }
        public virtual ICollection<JobsSaved> JobsSaveds { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
    }
}
