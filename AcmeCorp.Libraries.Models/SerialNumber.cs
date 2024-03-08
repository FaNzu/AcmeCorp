using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Models
{
	public class SerialNumber
	{
		public int Id { get; set; }
		public string VoucherKey { get; set; }
		public int DrawNumberUses { get; set; } = 2; //defualt value of 2

		public SerialNumber(string voucherKey)
		{
			VoucherKey = voucherKey;
			DrawNumberUses = 2;
		}
	}
}
