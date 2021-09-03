using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itians.Controllers.HelperClasses
{
	public class SkillModel
	{
		public int skillid { get; set; }
		[Required(ErrorMessage ="Skill Required")]
		public string skillname { get; set; }
	}
}
