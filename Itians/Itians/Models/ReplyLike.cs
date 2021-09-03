using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class ReplyLike
    {
        public int ReplyLikeId { get; set; }
        public int ReplyId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Reply Reply { get; set; }
        public virtual User User { get; set; }
    }
}
