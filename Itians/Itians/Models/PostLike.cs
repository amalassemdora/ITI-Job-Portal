using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class PostLike
    {
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
