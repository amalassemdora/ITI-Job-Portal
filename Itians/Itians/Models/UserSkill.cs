using System;
using System.Collections.Generic;

#nullable disable

namespace Itians.Models
{
    public partial class UserSkill
    {
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public short? SkillLevel { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
