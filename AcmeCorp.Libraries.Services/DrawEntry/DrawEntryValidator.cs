using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Libraries.Services
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

        //what is the return type for this?
        public string GenerateDrawEntry()
        {
            // LL-012345678


            //generate serial number
            //check if it isnt database
            //return number if it isnt
            return "valid-serial-number";
        }

        //view all keys in paged lists
        public List<string> GetAllDrawEntries()
        {
            //make sure user is logged in
            //open database, take all draw entries
            //return data
            return null;
        }
    }
}
