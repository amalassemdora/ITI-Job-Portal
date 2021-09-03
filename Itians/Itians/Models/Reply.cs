using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Reply
    {
        public Reply()
        {
            ReplyLikes = new HashSet<ReplyLike>();
        }

        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
    }
}
