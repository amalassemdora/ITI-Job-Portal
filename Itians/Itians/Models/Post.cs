using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostLikes = new HashSet<PostLike>();
        }

        public int PostId { get; set; }
        public int? GroupId { get; set; }
        public int AuthorId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Author { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}
