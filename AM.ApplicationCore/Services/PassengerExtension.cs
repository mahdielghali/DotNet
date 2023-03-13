using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p)
        {
            p.Fullname.FirstName = p.Fullname.FirstName[0].ToString().ToUpper() + p.Fullname.FirstName.Substring(1);
            p.Fullname.LastName = p.Fullname.LastName[0].ToString().ToUpper() + p.Fullname.LastName.Substring(1);
        }
    }
}
