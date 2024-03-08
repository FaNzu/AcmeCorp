using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class DrawEntryPostViewModel
	{
		public DrawEntryPostViewModel() { }
		public DrawEntryPostViewModel(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string VoucherKey { get; set; }
	}
}
