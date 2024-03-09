using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class PostLoginModel
	{
		[Required]
		public string loginName { get; set; }
		[Required]
		public string password { get; set; }
	}
}
