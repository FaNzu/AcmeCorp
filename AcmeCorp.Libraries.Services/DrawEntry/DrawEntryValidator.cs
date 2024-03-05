using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Services.DrawEntry
{
	public class DrawEntryValidator
	{
		//return type for this?, bool is temp
		public bool Validate(string SerialNumber)
		{
			if (SerialNumber == "valid-serial-number")
			{
				//check database for registered keys
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
