using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentLikes = new HashSet<CommentLike>();
            Replies = new HashSet<Reply>();
        }

        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentLike> CommentLikes { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
