using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class DrawEntry
	{
		public DrawEntry() { }
		public DrawEntry(string firstName, string lastName, string email, int serialnumberId)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			SerialNumberId = serialnumberId;
		}
		public DrawEntry(DrawEntryPostViewModel drawEntryPost)
		{
			FirstName = drawEntryPost.FirstName;
			LastName = drawEntryPost.LastName;
			Email = drawEntryPost.Email;
		}

		public int Id { get; set; } // Primary key 

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		//[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required]
		public int SerialNumberId { get; set; }

    }
}
