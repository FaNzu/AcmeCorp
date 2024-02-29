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

		public int Id { get; set; } // Primary key 

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string SerialNumber { get; set; }

		[Required]
		[Range(18, int.MaxValue)]
		public int Age { get; set; }

		public DateTime EntryDate { get; set; } = DateTime.UtcNow;
	}
}
