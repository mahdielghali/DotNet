using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public Boolean Vip { get; set; }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public int FlightFk { get; set; }
        public string PassengerFk { get; set; }
    }
}
