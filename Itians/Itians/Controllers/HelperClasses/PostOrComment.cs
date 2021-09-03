using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
    public class PostOrComment
    {
        public int postAuthor { get; set; }
        // With Group only
        public int ? groupId { get; set; }
        public string postBody { get; set; }
        public string commentBody { get; set; }
        public int postId { get; set; }
        public int commentAuthor { get; set; }
    }
}
